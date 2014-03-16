using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ErpBudgetBudgetDoc
{
    public partial class uctrlBudgetDocRoute : UserControl, IBudgetDocRoute
    {
        #region Переменные, свойства
        /// <summary>
        /// выбранный маршрут документа
        /// </summary>
        private ERP_Budget.Common.CRouteTemplate m_objCurrentRouteTmpl;
        /// <summary>
        /// список маршрутов с условиями их выбора
        /// </summary>
        private List<ERP_Budget.Common.CRouteCondition> m_objListCondition;
        /// <summary>
        /// Ссылка на объект "Заявка"
        /// </summary>
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;
        /// <summary>
        /// Список классов "Кто-При наличии какого динамического права-Может производить действия на бюджетом службы"
        /// </summary>
        private List<ERP_Budget.Common.CUserBudgetRights> m_objUserBudgetRightsList;
        /// <summary>
        /// Поток для загрузки списка доступных маршрутов
        /// </summary>
        private System.Threading.Thread thrLoadConditionForSelectRoute;

        private UniXP.Common.CProfile m_objProfile;

        private System.String m_strMainDynamicRight;
        private System.String m_strCanShow = ">>";
        private System.String m_strCanHide = "<<";
        private const System.String strCaptionNotOptimize = "Маршрут";
        private const System.String strCaptionOptimize = "Маршрут сокращен";
        #endregion

        #region События
        #region Изменение переменной маршрута
        // Создаем закрытое экземплярное поле для блокировки синхронизации потоков
        private readonly Object m_eventLock = new Object();
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeRouteEventArgs> m_ChangeRoute;
        // Создаем в классе член-событие
        public event EventHandler<ChangeRouteEventArgs> ChangeRoute
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                lock (m_eventLock) { m_ChangeRoute += value; }
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                lock (m_eventLock) { m_ChangeRoute -= value; }
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeRoute(ChangeRouteEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeRouteEventArgs> temp = m_ChangeRoute;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeRoute()
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeRouteEventArgs e = new ChangeRouteEventArgs(m_objCurrentRouteTmpl);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeRoute(e);
        }
        #endregion

        #region Спрятать/Показать панель
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeHideBtnStateEventArgs> m_ChangeHideBtn;
        // Создаем в классе член-событие
        public event EventHandler<ChangeHideBtnStateEventArgs> ChangeHideBtn
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                m_ChangeHideBtn += value;
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                m_ChangeHideBtn -= value;
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnHideBtn(ChangeHideBtnStateEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeHideBtnStateEventArgs> temp = m_ChangeHideBtn;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateHideBtn()
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            System.Boolean bCanShow = (btnHide.Text == m_strCanShow);
            ChangeHideBtnStateEventArgs e = new ChangeHideBtnStateEventArgs(this.Name, bCanShow, btnHide.Height);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnHideBtn(e);
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            try
            {
                btnHide.Text = (btnHide.Text == m_strCanHide) ? m_strCanShow : m_strCanHide;
                SimulateHideBtn();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "btnHide_Click.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #endregion

        #region Конструкторы
        public uctrlBudgetDocRoute(UniXP.Common.CProfile objProfile)
        {
            InitializeComponent();

            m_objCurrentRouteTmpl = null;
            m_objListCondition = null;
            m_objBudgetDoc = null;
            m_strMainDynamicRight = "";
            grCtrlRoute.Text = strCaptionNotOptimize;
            m_objUserBudgetRightsList = null;
            m_objProfile = objProfile;
        }
        public uctrlBudgetDocRoute(ERP_Budget.Common.CBudgetDoc objBudgetDoc,  
            System.String strDR,
            List<ERP_Budget.Common.CUserBudgetRights> objUserBudgetRightsList, 
            List<ERP_Budget.Common.CRouteCondition> objListCondition, 
            UniXP.Common.CProfile objProfile)
        {
            InitializeComponent();

            m_objCurrentRouteTmpl = null;
            m_objListCondition = objListCondition;
            m_objBudgetDoc = objBudgetDoc;
            m_strMainDynamicRight = strDR;
            grCtrlRoute.Text = strCaptionNotOptimize;
            m_objUserBudgetRightsList = objUserBudgetRightsList;
            m_objProfile = objProfile;
        }
        /// <summary>
        /// Загружает список маршрутов с условиями, при выполнении которых выбирается маршрут
        /// </summary>
        /// <returns>true - удачное завершение; false - ошибка или список пуст</returns>
        public void LoadConditionForSelectRoute( UniXP.Common.CProfile objProfile, List<ERP_Budget.Common.CRouteVariable> objInitRouteVariableList, 
            ref System.Int32 iRet, ref System.String strErr )
        {
            try
            {
                txtDR4Route.Text = m_strMainDynamicRight;
                grCtrlRoute.Text = String.Format("{0} [{1}]", strCaptionNotOptimize, m_strMainDynamicRight);

                if (objInitRouteVariableList != null)
                {
                    foreach (ERP_Budget.Common.CRouteVariable objRouteVariable in objInitRouteVariableList)
                    {
                        if (txtDR4Route.GetType().Name.IndexOf(objRouteVariable.EditClassName) == 0)
                        {
                            objRouteVariable.m_strValue = txtDR4Route.GetValue();
                        }
                    }
                }

                if (m_objListCondition == null)
                {
                    // запуск потока
                    this.thrLoadConditionForSelectRoute = new System.Threading.Thread(() => InitRouteConditionList(objProfile));
                    this.thrLoadConditionForSelectRoute.Start();
                }
            }
            catch (System.Exception f)
            {
                iRet = -1;
                strErr += ("LoadConditionForSelectRoute. Текст ошибки: " + f.Message);
            }

            return;
        }

        public void InitRouteConditionList(UniXP.Common.CProfile objProfile)
        {
            // список условий выбора маршрута
            m_objListCondition = ERP_Budget.Common.CRouteCondition.GetRouteConditionList( objProfile );
        }

        #endregion

        #region DrawRoute
        /// <summary>
        /// Отрисовывает маршрут
        /// </summary>
        /// <param name="objRoutePointList">список точек маршрута</param>
        /// <param name="IsNeedFillUserList">заполнять список пользователей</param>
        public void RouteDraw(List<ERP_Budget.Common.CRoutePoint> objRoutePointList, 
            System.Boolean IsNeedFillUserList)
        {
            try
            {
                // стираем все картинки
                //this.SuspendLayout();
                System.String strErr = System.String.Empty;

                ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlRouteImage)).BeginInit();
                this.pnlCtrlRouteImage.SuspendLayout();

                foreach (Control objControl in pnlCtrlRouteImage.Controls) { objControl.Dispose(); }
                pnlCtrlRouteImage.Controls.Clear();

                if ((objRoutePointList != null) && (objRoutePointList.Count > 0))
                {
                    // определяем точку, в которой начнем рисовать
                    System.Drawing.Point objStartPointLocation = new System.Drawing.Point(0, 0);
                    System.Int32 i = 0;
                    System.Boolean bFindCurPoint = false;
                    System.Boolean bIsCurPoint = false;
                    // проходим по списку точек маршрута
                    foreach (ERP_Budget.Common.CRoutePoint objRoutePoint in objRoutePointList)
                    {
                        bIsCurPoint = false;
                        // рисовать будем только пункты с пометкой "ShowInDocument"
                        if (objRoutePoint.ShowInDocument == false) { continue; }
                        if (i > 0)
                        {
                            // стрелка
                            System.Windows.Forms.Label lblNeedle = new Label();
                            lblNeedle.AutoSize = true;
                            lblNeedle.Location = new Point(objStartPointLocation.X, (objStartPointLocation.Y + 15));
                            lblNeedle.Name = "lblNeedle_" + i.ToString();
                            lblNeedle.Font = new System.Drawing.Font("Wingdings 3", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
                            lblNeedle.Text = "g";
                            lblNeedle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            pnlCtrlRouteImage.Controls.Add(lblNeedle);
                            objStartPointLocation = new Point(lblNeedle.Location.X + lblNeedle.Width + 5, objStartPointLocation.Y);
                        }
                        // в строку добавляем label и comboBoxEdit
                        // label
                        System.Windows.Forms.Label lblEventInfo = new System.Windows.Forms.Label();
                        lblEventInfo.AutoSize = true;
                        lblEventInfo.Name = "lbl_" + i.ToString();
                        lblEventInfo.Text = objRoutePoint.BudgetDocEvent.Name;
                        lblEventInfo.Location = objStartPointLocation;
                        pnlCtrlRouteImage.Controls.Add(lblEventInfo);
                        // нужно определить, в этой ли точке маршрута находится заявка
                        if ((m_objBudgetDoc.DocState != null) && (m_objBudgetDoc.IsActive) &&
                            (objRoutePoint.BudgetDocStateIN != null))
                        {
                            if (objRoutePoint.BudgetDocStateIN.uuidID.CompareTo(m_objBudgetDoc.DocState.uuidID) == 0)
                            {
                                lblEventInfo.Font = new Font(lblEventInfo.Font, FontStyle.Bold);
                                bFindCurPoint = true;
                                bIsCurPoint = true;
                            }
                        }
                        if ((this.m_objBudgetDoc.DocState == null) && (objRoutePoint.BudgetDocStateIN == null))
                        {
                            // мы в самой первой точке
                            lblEventInfo.Font = new Font(lblEventInfo.Font, FontStyle.Bold);
                            bFindCurPoint = true;
                            bIsCurPoint = true;
                        }

                        // comboBoxEdit
                        DevExpress.XtraEditors.ComboBoxEdit cboxEvent = new DevExpress.XtraEditors.ComboBoxEdit();
                        cboxEvent.Name = "cbx_" + i.ToString();
                        cboxEvent.Location = new Point(objStartPointLocation.X + 2, objStartPointLocation.Y + 19);
                        pnlCtrlRouteImage.Controls.Add(cboxEvent);
                        cboxEvent.Properties.PopupSizeable = true;
                        cboxEvent.Properties.Sorted = true;
                        cboxEvent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        cboxEvent.Size = new System.Drawing.Size(120, 22);
                        cboxEvent.Tag = objRoutePoint;
                        cboxEvent.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.cboxEvent_CloseUp);
                        if (objRoutePoint.UserEvent != null)
                        {
                            cboxEvent.Properties.Items.Add(objRoutePoint.UserEvent);
                            cboxEvent.SelectedItem = cboxEvent.Properties.Items[0];
                        }
                        else
                        {
                            cboxEvent.SelectedItem = null;
                        }
                        cboxEvent.Properties.ReadOnly = (IsNeedFillUserList == false);
                        if (bIsCurPoint)
                        {
                            // это текущая точка маршрута
                            cboxEvent.BackColor = Color.FromArgb(255, 255, 250);
                        }
                        if ((bFindCurPoint == false) && (bIsCurPoint == false))
                        {
                            // мы еще не прошли текущую точку маршрута
                            cboxEvent.BackColor = Color.FromArgb(255, 250, 250, 250);
                        }
                        // заполняем выпадающий список
                        if (IsNeedFillUserList == true)
                        {
                            if (i == 0)
                            {
                                // первая точка маршрута - должен быть один пользователь
                                cboxEvent.Properties.Items.Add(m_objBudgetDoc.OwnerUser);
                                cboxEvent.SelectedItem = cboxEvent.Properties.Items[0];
                                objRoutePoint.UserEvent = m_objBudgetDoc.OwnerUser;
                            }
                            else
                            {
                                //запрос списка пользователей, имеющих доступ к действию
                                System.Guid BudgetDocEvent_Guid = objRoutePoint.BudgetDocEvent.uuidID;
                                System.Guid BudgetDep_Guid = ( ( m_objBudgetDoc.BudgetDep != null ) ? m_objBudgetDoc.BudgetDep.uuidID : System.Guid.Empty );
                                System.Guid Budget_Guid = ( ( ( m_objBudgetDoc.BudgetItem != null ) && ( m_objBudgetDoc.BudgetItem.BudgetGUID.CompareTo( System.Guid.Empty ) != 0 ) ) ? m_objBudgetDoc.BudgetItem.BudgetGUID : System.Guid.Empty );

                                List<ERP_Budget.Common.CUser> objFilteredUserList = ERP_Budget.Common.CBudgetDocEvent.GetBudgetDocEventUserList(m_objProfile,
                                    BudgetDocEvent_Guid, BudgetDep_Guid, Budget_Guid, ref strErr);

                                if ((objFilteredUserList != null) && (objFilteredUserList.Count > 0))
                                {
                                    ERP_Budget.Common.CUser objSelectedUser = ((cboxEvent.SelectedItem != null) ? (ERP_Budget.Common.CUser)cboxEvent.SelectedItem : null);
                                    if (objSelectedUser != null)
                                    {
                                        if (objFilteredUserList.SingleOrDefault<ERP_Budget.Common.CUser>(x => x.ulID == objSelectedUser.ulID) == null)
                                        {
                                            cboxEvent.SelectedItem = null;
                                        }
                                    }

                                    cboxEvent.Properties.Items.Clear();
                                    cboxEvent.Properties.Items.AddRange(objFilteredUserList);

                                }
                                else
                                {
                                    foreach (ERP_Budget.Common.CUser objUser in objRoutePoint.BudgetDocEvent.UserList)
                                    {
                                        cboxEvent.Properties.Items.Add(objUser);
                                    }
                                }
                                
                            }
                        }

                        objStartPointLocation = new Point(lblEventInfo.Location.X + cboxEvent.Width + 5, lblEventInfo.Location.Y);
                        i++;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка отрисовки маршрута заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlRouteImage)).EndInit();
                this.pnlCtrlRouteImage.ResumeLayout(false);

                //this.ResumeLayout(false);
                this.Refresh();
            }
            return;
        }
        private void cboxEvent_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if ((e.AcceptValue == true) && (sender != null))
                {
                    ERP_Budget.Common.CUser objCurrentUser = (( ((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedItem != null ) ? (ERP_Budget.Common.CUser)((DevExpress.XtraEditors.ComboBoxEdit)sender).SelectedItem : null);
                    ERP_Budget.Common.CUser objNewUser = ( (e.Value != null ) ? (ERP_Budget.Common.CUser)e.Value : null);
                    if (((objCurrentUser == null) && (objNewUser != null)) ||
                        ((objCurrentUser != null) && (objNewUser != null) && (objNewUser.ulID != objCurrentUser.ulID)))
                    {
                        // значение  изменилось
                        // у выбранной точки маршрута в списке пользователей объекта "Действие"  найдем нужного пользователя
                        ERP_Budget.Common.CRoutePoint objCurrentPoint = (ERP_Budget.Common.CRoutePoint)((DevExpress.XtraEditors.ComboBoxEdit)sender).Tag;
                        objCurrentPoint.UserEvent = objNewUser;

                        // прописываем пользователей во всех точках маршрута заданной группы
                        SetUserForPointGroup(((ERP_Budget.Common.CRoutePoint)((DevExpress.XtraEditors.ComboBoxEdit)sender).Tag));

                        e.AcceptValue = true;

                        // инициируем событие "маршрут изменился"
                        SimulateChangeRoute();
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка выбора участника маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Поиск пользователя для точек маршрута, входящих в ту же группу, что и заданная точка маршрута
        /// </summary>
        /// <param name="objRoutePoint">точка маршрута</param>
        private void SetUserForPointGroup(ERP_Budget.Common.CRoutePoint objRoutePoint)
        {
            if ((objRoutePoint == null) || (objRoutePoint.UserEvent == null)) { return; }
            try
            {
                // проходим по всем точкам маршрута и исчем точки с группой такой же как у objRoutePoint
                foreach (ERP_Budget.Common.CRoutePoint objRoutePointItem in m_objCurrentRouteTmpl.RoutePointList)
                {
                    if (objRoutePointItem.RoutePointGroup.uuidID.CompareTo(objRoutePoint.RoutePointGroup.uuidID) == 0)
                    {
                        // группы совпадают, задаем пользователя данной точке маршрута
                        objRoutePointItem.UserEvent = objRoutePoint.UserEvent;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка поиска пользователя для группы точек маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region HideControl
        /// <summary>
        /// Минимизирует размеры элемента управления
        /// </summary>
        public void HideControl()
        {
            try
            {
                btnHide.Text = m_strCanShow;
                SimulateHideBtn();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "HideControl.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region DrawControl
        /// <summary>
        /// Отрисовывает элемент управления
        /// </summary>
        public void DrawControl()
        {
            try
            {
                this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка отрисовки элемента управления \"Маршрут\".\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region ClearRoute
        /// <summary>
        /// очищает маршрут
        /// </summary>
        public void ClearRoute()
        {
            try
            {
                m_objCurrentRouteTmpl = null;
                m_objBudgetDoc.Route = null;
                // отрисовываем маршрут
                RouteDraw(null, false);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка удаления маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        public void SetRouteTmplToNull()
        {
            try
            {
                m_objCurrentRouteTmpl = null;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка SetRouteTmplToNull.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region SetCurrentRoute
        /// <summary>
        /// Возвращает список точек маршрута
        /// </summary>
        public List<ERP_Budget.Common.CRoutePoint> GetRoutePointList()
        {
            try
            {
                if (m_objCurrentRouteTmpl != null)
                {
                    return m_objCurrentRouteTmpl.RoutePointList;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "GetRoutePointList.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return null;
        }
        #endregion

        #region SelectRoute
        /// <summary>
        /// Проверяет всем ли переменным, влияющим на выбор маршрута, присвоены значения
        /// </summary>
        /// <param name="objInitRouteVariableList">список переменных, влияющих на выбор маршрута документа</param>
        /// <returns>true - всем переменным присвоены значения; false - НЕ всем переменным присвоены значения</returns>
        private System.Boolean CheckRouteVariableValue(List<ERP_Budget.Common.CRouteVariable> objInitRouteVariableList)
        {
            System.Boolean bRet = true;
            try
            {
                if ((objInitRouteVariableList == null) || (objInitRouteVariableList.Count == 0)) { return false; }

                bRet = ( ( objInitRouteVariableList.FirstOrDefault<ERP_Budget.Common.CRouteVariable>(x => x.m_strValue == "") == null ) &&
                         (objInitRouteVariableList.FirstOrDefault<ERP_Budget.Common.CRouteVariable>(x => x.m_strValue == "0.") == null));
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции CheckRouteVariableValue.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bRet;
        }

        /// <summary>
        /// Устанавливает маршрут на основании списка переменных, влияющих на его выбор
        /// </summary>
        /// <param name="objInitRouteVariableList">список переменных, влияющих на выбор маршрута документа</param>
        /// <param name="strDR">с каким ДП выбирается маршрут</param>
        public void SelectRoute(List<ERP_Budget.Common.CRouteVariable> objInitRouteVariableList, System.String strDR)
        {
            System.Int32 iRet = 0;
            System.String strErr = "";

            try
            {
                if (txtDR4Route.Text != strDR)
                {
                    txtDR4Route.Text = strDR;
                    grCtrlRoute.Text = String.Format("{0} [{1}]", strCaptionNotOptimize, strDR);

                    // поменялось динамическое право ("Инициатор", "Распорядитель", ...)
                    // поиск переменной, связанной с динамическим правом и присваивание ей значения
                    ERP_Budget.Common.CRouteVariable objRouteVariable = objInitRouteVariableList.SingleOrDefault<ERP_Budget.Common.CRouteVariable>(x => x.EditClassName.IndexOf(txtDR4Route.GetType().Name) == 0);
                    if (objRouteVariable != null)
                    {
                        objRouteVariable.m_strValue = txtDR4Route.GetValue();
                    }
                }

                // проверка, все ли необходимые переменные заполнены значениями
                if (CheckRouteVariableValue(objInitRouteVariableList) == true)
                {
                    ERP_Budget.Common.CRouteCondition objRouteTemplateValid = ERP_Budget.Common.CRouteConditionAlgoritm.GetRouteTemplateForCondition(objInitRouteVariableList, m_objListCondition, ref iRet, ref strErr);
                    
                    if( ( (m_objCurrentRouteTmpl == null) && ( objRouteTemplateValid == null ) ) ||
                        ((m_objCurrentRouteTmpl != null) && (objRouteTemplateValid != null) && (m_objCurrentRouteTmpl.uuidID.CompareTo(objRouteTemplateValid.RouteTemplate.uuidID) == 0)))
                    {
                        // текущий и новый маршрут не определены
                        // или текщий мрашрут совпадает с новым
                    }
                    else
                    {
                        m_objCurrentRouteTmpl = objRouteTemplateValid.RouteTemplate;
                    }

                    // отрисовываем маршрут
                    RouteDraw(m_objCurrentRouteTmpl.RoutePointList, true);

                    // инициируем событие "маршрут изменился"
                    SimulateChangeRoute();

                    if (btnHide.Text == m_strCanShow)
                    {
                        btnHide.Text = m_strCanHide;
                        SimulateHideBtn();
                    }
                }
                else
                {
                    // не все переменные проинициализированы
                    if (m_objCurrentRouteTmpl != null)
                    {
                        // документу ранее был назначен маршрут, производится его очистка
                        ClearRoute();

                        // инициируем событие "маршрут изменился"
                        SimulateChangeRoute();
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка поиска маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region ShowOptimizeBtn
        /// <summary>
        /// Отображает/прячет кнопку оптимизации маршрута
        /// </summary>
        /// <param name="bShow">true - показать; false - спрятать</param>
        public void ShowOptimizeBtn(System.Boolean bShow)
        {
            try
            {
                grCtrlRoute.Text = (bShow == true) ? strCaptionOptimize : strCaptionNotOptimize;
                grCtrlRoute.Appearance.Font = (bShow == true) ? new Font(grCtrlRoute.Appearance.Font, FontStyle.Bold) : new Font(grCtrlRoute.Appearance.Font, FontStyle.Regular);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка отображения кнопки оптимизации.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведеомления о событии
    /// </summary>
    public partial class ChangeRouteEventArgs : EventArgs
    {
        /// <summary>
        /// Признак того, что маршрут выбран
        /// </summary>
        private readonly System.Boolean m_bRouteIsSelected;
        public System.Boolean RouteIsSelected
        { get { return m_bRouteIsSelected; } }
        /// <summary>
        /// Признак того, все ли точки маршрута определены
        /// </summary>
        private readonly System.Boolean m_bRouteIsFull;
        public System.Boolean RouteIsFull
        { get { return m_bRouteIsFull; } }
        /// <summary>
        /// Признак того, что маршрут можно оптимизировать
        /// </summary>
        private readonly System.Boolean m_bCanOptimize;
        public System.Boolean CanOptimize
        { get { return m_bCanOptimize; } }

        public ChangeRouteEventArgs(ERP_Budget.Common.CRouteTemplate objCurrRouteTmpl)
        {
            m_bRouteIsFull = CheckRoute(objCurrRouteTmpl);
            m_bRouteIsSelected = (objCurrRouteTmpl != null);
            if (m_bRouteIsFull == false)
            {
                m_bCanOptimize = false;
            }
            else
            {
                m_bCanOptimize = ERP_Budget.Common.CRouteTemplate.IsCanOptimize( objCurrRouteTmpl.RoutePointList );
            }
        }
        /// <summary>
        /// Проверяет, во всех ли точках маршрута указан пользователь
        /// </summary>
        /// <param name="objCurrRouteTmpl">шаблон маршрута</param>
        /// <returns>true - все точки маршрута определены; false - маршрут не определен или ошибка</returns>
        private System.Boolean CheckRoute(ERP_Budget.Common.CRouteTemplate objCurrRouteTmpl)
        {
            System.Boolean bRet = false;
            try
            {
                if (objCurrRouteTmpl != null)
                {
                    System.Boolean bOK = false;
                    foreach (ERP_Budget.Common.CRoutePoint objRoutePoint in objCurrRouteTmpl.RoutePointList)
                    {
                        bOK = (objRoutePoint.UserEvent != null);
                        if (bOK == false) { break; }
                    }

                    bRet = bOK;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка проверки заполнения маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bRet;
        }
    }

}
