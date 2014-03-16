using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
    public partial class uctrlBudgetDocEvent : UserControl, IBudgetDocEvent
    {
        #region Переменные, свойства
        /// <summary>
        /// Список возможных действий
        /// </summary>
        List<ERP_Budget.Common.CBudgetDocEvent> m_objDocEventList;
        private System.String m_strCanShow = ">>";
        private System.String m_strCanHide = "<<";
        private const System.Int32 m_iCalcWidth = 120;
        public double EventMoney
        {
            get { return System.Convert.ToDouble(calcEventMoney.Value); }
        }
        private double m_BudgetDocMoney;
        public double BudgetDocMoney
        {
            set { m_BudgetDocMoney = value; }
        }
        private double m_BudgetDocMoneyPayment;
        public double BudgetDocMoneyPayment
        {
            set { m_BudgetDocMoneyPayment = value; }
        }
        #endregion

        #region События

        #region Изменилось действие
        // Создаем закрытое экземплярное поле для блокировки синхронизации потоков
        private readonly Object m_eventLock = new Object();
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeDocEvenEventArgs> m_ChangeDocEven;
        // Создаем в классе член-событие
        public event EventHandler<ChangeDocEvenEventArgs> ChangeDocEven
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                lock (m_eventLock) { m_ChangeDocEven += value; }
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                lock (m_eventLock) { m_ChangeDocEven -= value; }
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeDocEven(ChangeDocEvenEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeDocEvenEventArgs> temp = m_ChangeDocEven;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeDocEven()
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeDocEvenEventArgs e = new ChangeDocEvenEventArgs(GetSelectedEvent());

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeDocEven(e);
        }
        private void rgrDocEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SimulateChangeDocEven();
                if ((rgrDocEvent.SelectedIndex >= 0) && (btnHide.Text == m_strCanShow))
                {
                    btnHide.Text = m_strCanHide;
                    SimulateHideBtn();
                }
                // мы выбрали действие, проверим, можно ли отображать и менять сумму
                ERP_Budget.Common.CBudgetDocEvent objBudgetDocEvent = GetSelectedEvent();
                if (objBudgetDocEvent != null)
                {
                    tableLayoutPanel.ColumnStyles[1].Width = (objBudgetDocEvent.IsShowMoney == true) ? m_iCalcWidth : 0;
                    calcEventMoney.Properties.ReadOnly = !(objBudgetDocEvent.IsCanChanhgeMoney);
                    calcEventMoney.ToolTip = "Укажите сумму для выбранного действия: \"" + objBudgetDocEvent.Name + "\"";
                }
                
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка при изменении выбранного действия.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                SetBackGroundColor();
            }
            return;
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

        #region Конструктор
        public uctrlBudgetDocEvent()
        {
            InitializeComponent();

            m_objDocEventList = null;
            m_BudgetDocMoney = 0;
            m_BudgetDocMoneyPayment = 0;
            DrawControl();
            tableLayoutPanel.ColumnStyles[1].Width = 0;
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
                SetBackGroundColor();
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

        #region CreateEventList
        /// <summary>
        /// Очищает список возможных действий
        /// </summary>
        public void ClearEventList()
        {
            try
            {
                rgrDocEvent.Properties.Items.Clear();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка очистки списка возможных действий.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Построение списка возможных действий
        /// </summary>
        /// <param name="objRoutePointList">список точек маршрута</param>
        /// <param name="objCurrentUser">пользователь, рпботающий в данный момент с документом</param>
        /// <param name="objDocState">состояние документа</param>
        /// <param name="objProfile">профайл</param>
        public void CreateEventList(List<ERP_Budget.Common.CRoutePoint> objRoutePointList,
            ERP_Budget.Common.CUser objCurrentUser, ERP_Budget.Common.CBudgetDocState objDocState,
            UniXP.Common.CProfile objProfile, ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            try
            {
                // структура маршрута
                rgrDocEvent.Properties.Items.Clear();
                if ((objRoutePointList == null) || (objRoutePointList.Count == 0)) { return; }

                // у нас есть список точек маршрута, определим в какой точке находится заявка
                m_objDocEventList = new List<ERP_Budget.Common.CBudgetDocEvent>();
                if (objDocState == null)
                {
                    // новая заявка
                    foreach (ERP_Budget.Common.CRoutePoint objPoint in objRoutePointList)
                    {
                        if (objPoint.BudgetDocStateIN == null)
                        {
                            m_objDocEventList.Add(objPoint.BudgetDocEvent);
                        }
                    }
                }
                else
                {
                    // уже сохраненная заявка
                    foreach (ERP_Budget.Common.CRoutePoint objPoint in objRoutePointList)
                    {
                        if (objPoint.BudgetDocStateIN == null) { continue; }
                        if (objPoint.BudgetDocStateIN.uuidID.CompareTo(objDocState.uuidID) == 0)
                        {
                            // нашли действие для текущего состояния
                            if (objCurrentUser == null) { continue; }
                            if (objCurrentUser.IsAccessToDocEvent(objPoint.BudgetDocEvent))
                            {
                                // у текущего пользователя есть доступ к этому действию
                                if (objPoint.UserEvent != null)
                                {
                                    // в точке маршрута указан конкретный пользователь
                                    if ((objPoint.UserEvent.ulID == objCurrentUser.ulID) ||
                                        (objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRAddRight)))
                                    {
                                        // пользователи совпадают или у текущего пользователя есть дополнительное право
                                        m_objDocEventList.Add(objPoint.BudgetDocEvent);
                                    }
                                }
                            }
                        }
                    }
                }

                // если список действий не пустой, то рисуем его
                foreach (ERP_Budget.Common.CBudgetDocEvent objDocEvent in m_objDocEventList)
                {
                    // добавляем радиометку
                    rgrDocEvent.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(objDocEvent, objDocEvent.Name));
                }
                // пропишем сумму, над которой совершается действие
                m_BudgetDocMoney = (objBudgetDoc == null) ? 0 : objBudgetDoc.Money;
                m_BudgetDocMoneyPayment = (objBudgetDoc == null) ? 0 : objBudgetDoc.MoneyPayment;

                decimal CalcValue = new decimal((m_BudgetDocMoney - m_BudgetDocMoneyPayment));
                calcEventMoney.Value = CalcValue;
                
                rgrDocEvent.Properties.Columns = rgrDocEvent.Properties.Items.Count;
                if (rgrDocEvent.Properties.Items.Count == 1) { rgrDocEvent.SelectedIndex = 0; }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка построения списка возможных действий.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                SetBackGroundColor();
            }

            return;
        }
        #endregion

        #region GetSelectedEvent
        /// <summary>
        /// Возвращает выбранное действие
        /// </summary>
        /// <returns></returns>
        public ERP_Budget.Common.CBudgetDocEvent GetSelectedEvent()
        {
            ERP_Budget.Common.CBudgetDocEvent objDocEvent = null;
            try
            {
                if ((m_objDocEventList != null) && (m_objDocEventList.Count > 0)
                    && (rgrDocEvent.SelectedIndex >= 0))
                {
                    objDocEvent = m_objDocEventList[rgrDocEvent.SelectedIndex];
                    objDocEvent.EventMoney = ( ( objDocEvent.IsShowMoney == true ) && ( objDocEvent.IsCanChanhgeMoney == true ) ) ? System.Convert.ToDouble(calcEventMoney.Value) : 0;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка определения выбранного действия.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return objDocEvent;
        }
        #endregion

        #region GetEventCount
        /// <summary>
        /// Возвращает доступное количество действий над бюджетным документом
        /// </summary>
        /// <returns>доступное количество действий над бюджетным документом</returns>
        public System.Int32 GetEventCount()
        {
            System.Int32 iRet = 0;
            try
            {
                if (m_objDocEventList != null)
                {
                    iRet = m_objDocEventList.Count;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка подсчета количества возможных действий.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return iRet;
        }
        #endregion

        /// <summary>
        /// Меняет цвет фона
        /// </summary>
        private void SetBackGroundColor()
        {
            try
            {
                if (rgrDocEvent.Properties.Items.Count > 0)
                {
                    rgrDocEvent.BackColor = System.Drawing.SystemColors.Info;
                }
                else
                {
                    rgrDocEvent.BackColor = System.Drawing.Color.FromArgb( 247, 245, 241 );
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "SetBackGroundColor.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void calcEventMoney_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (e.NewValue != null)
                {
                    e.Cancel = ((System.Convert.ToDecimal(e.NewValue) > System.Convert.ToDecimal(m_BudgetDocMoney - m_BudgetDocMoneyPayment) ) || (System.Convert.ToDecimal(e.NewValue) == 0));
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "calcEventMoney_EditValueChanging.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void calcEventMoney_EditValueChanged(object sender, EventArgs e)
        {
            SimulateChangeDocEven();
        }

    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведеомления о событии
    /// </summary>
    public partial class ChangeDocEvenEventArgs : EventArgs
    {
        /// <summary>
        /// Признак того, все ли точки маршрута определены
        /// </summary>
        private readonly ERP_Budget.Common.CBudgetDocEvent m_objBudgetDocEvent;
        public ERP_Budget.Common.CBudgetDocEvent BudgetDocEvent
        { get { return m_objBudgetDocEvent; } }

        public ChangeDocEvenEventArgs(ERP_Budget.Common.CBudgetDocEvent objBudgetDocEvent)
        {
            m_objBudgetDocEvent = objBudgetDocEvent;
        }
    }

}
