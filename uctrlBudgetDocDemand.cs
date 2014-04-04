using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using ERP_Budget.Common;
using System.Linq;

namespace ErpBudgetBudgetDoc
{
    #region Список вариантов отображения заявки
    /// <summary>
    /// Список вариантов отображения заявки
    /// </summary>
    public enum enumViewDocVariant
    {
        Unkown = 0,
        /// <summary>
        /// Скрыть действия, можно редактировать все
        /// </summary>
        HideAction = 1,      
        /// <summary>
        /// Скрыть действия, все заблокировать
        /// </summary>
        Arj = 2, 
        /// <summary>
        /// Отобразить действия, можно редактировать все
        /// </summary>   
        Full = 3,  
        /// <summary>
        /// Скрыть действия, заблокировать элементы управления, связанные с условием выбора маршрута
        /// </summary>
        BlockControl = 4,
        /// <summary>
        /// Отобразить действия, заблокировать элементы управления, связанные с условием выбора маршрута
        /// </summary>
        OnlyAction = 5,  
        /// <summary>
        /// Новая заявка
        /// </summary>
        NewDocument = 6      
    }
    #endregion

    public partial class uctrlBudgetDocDemand : UserControl, IBudgetDoc
    {
        #region Переменные, свойства
        /// <summary>
        /// Ссылка на объект "Профайл"
        /// </summary>
        private UniXP.Common.CProfile m_objProfile;
        /// <summary>
        /// Ссылка на объект "Бюджетный документ"
        /// </summary>
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;
        /// <summary>
        /// Ссылка на список переменных, влияющих на выбор маршрута
        /// </summary>
        private List<ERP_Budget.Common.CRouteVariable> m_objRouteVariableList;
        /// <summary>
        /// Ссылка на список переменных, влияющих на выбор маршрута
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocTypeVariable> m_objDocTypeVariableList;
        /// <summary>
        /// список курсов валют
        /// </summary>
        private System.Collections.Generic.List<ERP_Budget.Common.CCurrencyRateItem> m_objCurrencyRateList;
        /// <summary>
        /// список курсов валют
        /// </summary>
        private System.Collections.Generic.List<ERP_Budget.Common.CCurrencyRateItem> m_objCurrencyRateListForDivision;
        /// <summary>
        /// Признак того, что сумма документа меняется из списка дочерних статей
        /// </summary>
        private System.Boolean m_bWriteFromChildList;
        /// <summary>
        /// Признак "Проверка баланса"
        /// </summary>
        private System.Boolean m_bNeedCheckBalance;
        /// <summary>
        /// Вариант отображения заявки
        /// </summary>
        private enumViewDocVariant m_ViewDocVariant;
        /// <summary>
        /// Состояние документа
        /// </summary>
        private enumDocStateVariant m_DocStateVariant;
        /// <summary>
        /// Динамическое право для работы с документом
        /// </summary>
        private System.String m_strDR;
        private System.String m_strMainDynamicRight;
        /// <summary>
        /// Признак того, что пользователь, открывший заявку, должен произвести действие над ней
        /// </summary>
        private System.Boolean m_bIsActionUser;
        /// <summary>
        /// Признак того, что пользователь первым открывает заявку
        /// </summary>
        private System.Boolean m_IOpenDoc;
        /// <summary>
        /// Признак того, что над документом можно производить действия
        /// </summary>
        private System.Boolean m_bNeedEvent;
        private const System.String strLoadText = "загрузка...";
        private const System.Int32 iOpenPnlHight = 45;
        private const System.String strLblPaymentDate = "Дата оплаты";
        private const System.String strLblBudgetForPopupArticleList = "Бюджет";

        #endregion

        #region События

        #region Маршрут
        // Создаем закрытое экземплярное поле для блокировки синхронизации потоков
        private readonly Object m_eventLock = new Object();
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeRouteVariableEventArgs> m_ChangeRouteVariable;
        // Создаем в классе член-событие
        public event EventHandler<ChangeRouteVariableEventArgs> ChangeRouteVariable
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                lock (m_eventLock) { m_ChangeRouteVariable += value; }
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                lock (m_eventLock) { m_ChangeRouteVariable -= value; }
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeRouteVariable(ChangeRouteVariableEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeRouteVariableEventArgs> temp = m_ChangeRouteVariable;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeRouteVariable(ERP_Budget.Common.CRouteVariable objRouteVariable)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeRouteVariableEventArgs e = new ChangeRouteVariableEventArgs(objRouteVariable);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeRouteVariable(e);
        }
        #endregion

        #region Тип документа
        // Создаем закрытое экземплярное поле для блокировки синхронизации потоков
        private readonly Object m_eventLock2 = new Object();
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeDocTypeVariableEventArgs> m_ChangeDocTypeVariable;
        // Создаем в классе член-событие
        public event EventHandler<ChangeDocTypeVariableEventArgs> ChangeDocTypeVariable
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                lock (m_eventLock2) { m_ChangeDocTypeVariable += value; }
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                lock (m_eventLock2) { m_ChangeDocTypeVariable -= value; }
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeDocTypeVariable(ChangeDocTypeVariableEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeDocTypeVariableEventArgs> temp = m_ChangeDocTypeVariable;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeDocTypeVariable(ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariable)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeDocTypeVariableEventArgs e = new ChangeDocTypeVariableEventArgs(objDocTypeVariable);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeDocTypeVariable(e);
        }
        #endregion

        #region Свойства заявки
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeBudgetDocPropertieEventArgs> m_ChangeBudgetDocPropertie;
        // Создаем в классе член-событие
        public event EventHandler<ChangeBudgetDocPropertieEventArgs> ChangeBudgetDocPropertie
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                m_ChangeBudgetDocPropertie += value;
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                m_ChangeBudgetDocPropertie -= value;
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeBudgetDocPropertie(ChangeBudgetDocPropertieEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeBudgetDocPropertieEventArgs> temp = m_ChangeBudgetDocPropertie;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateChangeBudgetDocPropertie(System.String strPropertieName)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeBudgetDocPropertieEventArgs e = new ChangeBudgetDocPropertieEventArgs(strPropertieName);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnChangeBudgetDocPropertie(e);
        }
        #endregion

        #endregion

        #region Конструктор
        public uctrlBudgetDocDemand(UniXP.Common.CProfile objProfile,
            ERP_Budget.Common.CBudgetDoc objBudgetDoc,
           List<ERP_Budget.Common.CRouteVariable> objRouteVariableList,
           List<ERP_Budget.Common.CBudgetDocTypeVariable> objDocTypeVariableList,
           enumDocStateVariant DocStateVariant, System.String strDR, System.String strMainDynamicRight,
            System.Boolean bIsActionUser, System.Boolean bNeedEvent)
        {
            InitializeComponent();

            m_objProfile = objProfile;
            m_objBudgetDoc = objBudgetDoc;
            m_objRouteVariableList = objRouteVariableList;
            m_objDocTypeVariableList = objDocTypeVariableList;
            m_objCurrencyRateList = null;
            m_objCurrencyRateListForDivision = null;
            m_bWriteFromChildList = false;
            m_bNeedCheckBalance = false;
            m_ViewDocVariant = enumViewDocVariant.Unkown;
            m_DocStateVariant = DocStateVariant;
            m_strDR = strDR;
            m_strMainDynamicRight = strMainDynamicRight;
            m_bIsActionUser = bIsActionUser;
            m_bNeedEvent = bNeedEvent;
            m_IOpenDoc = false;
            cboxAccountPlan.Properties.ReadOnly = !(this.m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDREditAccountPlanInBudgetDocument));
            //cboxAccountPlan.Visible = this.m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDREditAccountPlanInBudgetDocument);
            //lblAccountPlan.Visible = cboxAccountPlan.Visible;
            InitVariables();
        }
        private void InitVariables()
        {
            try
            {
                //сперва нужно определить вариант отображения заявки
                SetViewDocVariant();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
               "Ошибка инициализации переменных\n\nТекст ошибки: " + f.Message, "Внимание",
               System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Возвращает вариант представления заявки
        /// </summary>
        /// <returns>вариант представления заявки</returns>
        private void SetViewDocVariant()
        {
            try
            {
                switch (m_DocStateVariant)
                {
                    case enumDocStateVariant.NewDocument:
                        m_ViewDocVariant = enumViewDocVariant.NewDocument;
                        break;
                    case enumDocStateVariant.SavedDocument:
                        m_ViewDocVariant = (m_bIsActionUser == true) ? enumViewDocVariant.BlockControl : enumViewDocVariant.Arj;
                        break;
                    case enumDocStateVariant.ArjDocument:
                        m_ViewDocVariant = enumViewDocVariant.Arj;
                        break;
                    default:
                        m_ViewDocVariant = enumViewDocVariant.Unkown;
                        break;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка поиска варианта отображения заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
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
                "DrawControl.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        //Открытие документа

        #region GetOpenDocFlag
        public System.Boolean GetOpenDocFlag()
        {
            return m_IOpenDoc;
        }
        #endregion

        #region bOpenBudgetDoc

        private void ShowHideWarningPnl(System.Boolean bShow, Color colorButton, System.String strTop, System.String strButton)
        {
            try
            {
                lblOpenInfoTop.Text = strTop;
                lblOpenInfoBotton.Text = strButton;
                lblOpenInfoBotton.ForeColor = colorButton;
                tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = ( (bShow == true) ? iOpenPnlHight : 0 );
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка ShowHideWarningPnl.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Открывает заявку
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        public System.Boolean bOpenBudgetDoc()
        {
            System.Boolean bRet = false;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            if ((m_objBudgetDoc == null) || (m_ViewDocVariant == enumViewDocVariant.Unkown)) { return bRet; }
            try
            {
                // если заявка открывается не в режиме "только просмотр", то проверяем, а не открыл ли ее кто-то другой
                System.String strOpenInfo = m_objBudgetDoc.GetOpenPropertieState(m_objProfile);
                if ((m_ViewDocVariant != enumViewDocVariant.Arj) && (strOpenInfo != ""))
                {
                    // заявку открыл кто-то другой
                    m_IOpenDoc = false;
                    m_ViewDocVariant = enumViewDocVariant.Arj;
                    lblOpenInfoTop.Text = m_objBudgetDoc.DocType.Name + " в данный момент открыта ";
                    lblOpenInfoBotton.Text = strOpenInfo;
                    tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = iOpenPnlHight;
                }
                else
                {
                    // заявку никто не открывал 
                    if (m_ViewDocVariant != enumViewDocVariant.NewDocument)
                    {
                        m_IOpenDoc = true;
                        m_bNeedCheckBalance = true;
                        if (m_objBudgetDoc.SetOpenPropertie(true, m_objProfile) == false)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось сделать пометку об открытиии заявки.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            return bRet;
                        }
                    }
                    tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = 0;
                }

                // теперь открываем заявку согласна выбранного варианта
                switch (m_ViewDocVariant)
                {
                    case enumViewDocVariant.Arj:
                        {
                            bRet = bOpenBudgetDocArj();
                            break;
                        }
                    case enumViewDocVariant.NewDocument:
                        {
                            bRet = bOpenBudgetDocNew();
                            break;
                        }
                    case enumViewDocVariant.BlockControl:
                        {
                            bRet = bOpenBudgetDocBlockControl();
                            break;
                        }
                    default:
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Не удалось определить режим отображения заявки.", "Внимание",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            break;
                        }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка открытия заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }
        #endregion

        #region Неактивная заявка
        /// <summary>
        /// Открывает ранее созданную заявку в режиме Arj
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        private System.Boolean bOpenBudgetDocArj()
        {
            System.Boolean bRet = false;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            if (m_objBudgetDoc == null) { return bRet; }
            try
            {
                // прячем баланс по статье
                txtRestMoneyDebitArticle.Visible = false;
                // прячем пересчет в валюту бюджета
                tlaypnlDemand_2.ColumnStyles[tlaypnlDemand_2.ColumnCount - 1].SizeType = SizeType.Absolute;
                tlaypnlDemand_2.ColumnStyles[tlaypnlDemand_2.ColumnCount - 1].Width = 0;
                tlaypnlDemand_2.ColumnStyles[tlaypnlDemand_2.ColumnCount - 2].Width = 50;
                // прячем столбец "Остаток"
                colRestMoney.VisibleIndex = -1;
                checkChildBudgetItem.Properties.ReadOnly = true;

                // присваиваем элементам управления значения из свойств заявки
                bRet = bResetBudgetDocControls();
                if (bRet)
                {
                    // блокируем элементы управления
                    cboxBudgetDep.Enabled = false;
                    cboxCompany.Enabled = false;
                    cboxPaymentType.Enabled = false;
                    dtDocPaymentDate.Enabled = false;
                    dtDocDate.Enabled = false;
                    cboxCurrency.Enabled = false;
                    cboxAccountPlan.Enabled = false;
                    cboxBudgetProject.Enabled = false;
                    txtDocMoney.Enabled = false;
                    cboxDebitArticle.Enabled = false;
                    txtDocBasis.Enabled = false;
                    txtDocObjective.Enabled = false;
                    txtDocReceipt.Enabled = false;
                    txtDocDescription.Enabled = false;
                }
                // меняем фон
                ChangeBackGrnd();
                // если есть вложения, то нарисуем и их
                LoadAttachList();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка открытия заявки.\nФункция bOpenBudgetDocArj\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }
        #endregion

        #region Ранее сохраненная заявка
        /// <summary>
        /// Открывает ранее созданную заявку в режиме BlockControl
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        private System.Boolean bOpenBudgetDocBlockControl()
        {
            System.Boolean bRet = false;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            if (m_objBudgetDoc == null) { return bRet; }
            try
            {
                checkChildBudgetItem.Properties.ReadOnly = true;

                // присваиваем элементам управления значения из свойств заявки
                bRet = bResetBudgetDocControls();
                if (bRet)
                {
                    // теперь нужно заблокировать некоторые элементы управления
                    cboxCurrency.Properties.ReadOnly = true;
                    cboxBudgetDep.Properties.ReadOnly = true;
                    cboxAccountPlan.Properties.ReadOnly = true;
                    cboxBudgetProject.Properties.ReadOnly = true;
                    cboxPaymentType.Enabled = false;
                    dtDocDate.Enabled = false;
                    if (this.m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCashier) == true)
                    {
                        dtDocPaymentDate.Enabled = true;
                        dtDocPaymentDate.Font = new Font(dtDocPaymentDate.Font, FontStyle.Bold );
                        lblPaymentDate.Text = strLblPaymentDate;
                        lblOpenInfoTop.Text = "Внимание! Документ будет оплачен датой, указанной в \"" + strLblPaymentDate + "\".";
                        lblOpenInfoBotton.Text = "В случае необходимости измените дату оплаты.";
                        tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = iOpenPnlHight;
                    }
                    else
                    {
                        dtDocPaymentDate.Enabled = false;
                    }
                    txtDocMoney.Enabled = false;
                    cboxDebitArticle.Enabled = false;
                }
                // если есть вложения, то нарисуем и их
                LoadAttachList();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка открытия заявки.\nФункция bOpenBudgetDocBlockControl\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }
        #endregion

        #region Новая заявка
        /// <summary>
        /// Создает новую заявку
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        private System.Boolean bOpenBudgetDocNew()
        {
            System.Boolean bRet = false;
            try
            {
                if (m_objBudgetDoc == null) { return bRet; }

                // заполним выпадающие списки
                RefreshAllComboBox();

                // корректируем список компаний - оставляем только активные компании

                // список курсов валют
                LoadCurrencyRateList();

                // маршрут будет меняться и нужно это отслеживать
                BindRouteVariablesWithControls();
                BindDocTypeVariablesWithControls();
                // баланс по статье нужно проверять
                m_bNeedCheckBalance = true;

                if (bResetBudgetDocControls() == true)
                {
                    // прячем/отображаем список подстатей
                    SetTreeListBudgetItemSize();
                    bRet = true;
                }
                dtDocDate.Enabled = ((this.m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCashier) == true) ||
                    (this.m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRAccountant) == true));
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка создания новой заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }
        /// <summary>
        /// Обновляет содержимое выпадающих списков
        /// </summary>
        private void RefreshAllComboBox()
        {
            try
            {
                // Службы
                cboxBudgetDep.Properties.Items.Clear();
                List<ERP_Budget.Common.CBudgetDep> objBudgetDepList = ERP_Budget.Common.CBudgetDep.GetBudgetDepsListForBudgetDoc( m_objProfile, false, false );
                if ((objBudgetDepList != null) && (objBudgetDepList.Count > 0))
                {
                    cboxBudgetDep.Properties.Items.AddRange(objBudgetDepList);
                }
                objBudgetDepList = null;

                // Компании
                cboxCompany.Properties.Items.Clear();
                List<ERP_Budget.Common.CCompany> objCompanyList = ERP_Budget.Common.CCompany.GetCompanyList(m_objProfile);
                if ((objCompanyList != null) && (objCompanyList.Count > 0))
                {
                    if( m_ViewDocVariant == enumViewDocVariant.Arj )
                    {
                        cboxCompany.Properties.Items.AddRange(objCompanyList);
                    }
                    else
                    {
                        cboxCompany.Properties.Items.AddRange(objCompanyList.Where<ERP_Budget.Common.CCompany>(x => x.IsActive == true).ToList<ERP_Budget.Common.CCompany>());
                    }
                }
                objCompanyList = null;

                // Формы расчетов
                cboxPaymentType.Properties.Items.Clear();
                List<ERP_Budget.Common.CPaymentType> objPaymentTypeList = ERP_Budget.Common.CPaymentType.GetPaymentTypesList(m_objProfile);
                if ((objPaymentTypeList != null) && (objPaymentTypeList.Count > 0))
                {
                    cboxPaymentType.Properties.Items.AddRange(objPaymentTypeList);
                }
                objPaymentTypeList = null;

                // Валюты
                cboxCurrency.Properties.Items.Clear();
                List<ERP_Budget.Common.CCurrency> objCurrencyList = ERP_Budget.Common.CCurrency.GetCurrencyList(m_objProfile);

                if ((objCurrencyList != null) && (objCurrencyList.Count > 0))
                {
                    cboxCurrency.Properties.Items.AddRange(objCurrencyList);
                }
                objCurrencyList = null;

                // Статьи расходов
                cboxDebitArticle.Properties.Items.Clear();
                // План счетов
                cboxAccountPlan.Properties.Items.Clear();
                // Проекты
                cboxBudgetProject.Properties.Items.Clear();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления содержимого выпадающих списков\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region Копия документа
        public System.Boolean CopyBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            System.Boolean bRet = false;
            try
            {
                if ((m_objBudgetDoc == null) || (objBudgetDoc == null)) { return bRet; }

                m_bNeedCheckBalance = true;
                tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = 0;
                // создаем новый документ
                bRet = bOpenBudgetDocNew();
                if (bRet == true)
                {
                    // удалось создать новый документ, теперь пропишем его свойства из исходного документа
                    // скопируем свойства исходной заявки в текущую
                    m_objBudgetDoc.Copy(objBudgetDoc);

                    // теперь осторожно и аккуратно в нужном порядке проверяем,
                    // есть ли в выпадающих списках нужные нам значения и выбираем их
                    bRet = bCopyPropertiesToBudgetDocControls(objBudgetDoc);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка копирования заявки.\nCopyBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc)\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }

        #endregion

        #region Установка значений в элементах управления
        private void WriteBudgetExpenseType( ERP_Budget.Common.CBudgetExpenseType objExpenseType )
        {
            grCtrlDoc.Text = ((objExpenseType != null) ? (String.Format(" [{0}]", objExpenseType.Name)) : "");
        }

        /// <summary>
        /// Присваивает элементам управления значения свойств объекта "Заявка"
        /// </summary>
        /// <returns>true - удачное завершение; false - ошибка</returns>
        private System.Boolean bResetBudgetDocControls()
        {
            System.Boolean bRet = false;
            if (m_objBudgetDoc == null) { return bRet; }
            try
            {
                txtDocMoney.Enabled = false;
                // сперва поотключаем обработчики событий
                //txtDocMoney.EditValueChanged -= new EventHandler(EditValueChanged);
                txtDocReceipt.EditValueChanged -= new EventHandler(EditValueChanged);
                txtDocObjective.EditValueChanged -= new EventHandler(EditValueChanged);
                txtDocBasis.EditValueChanged -= new EventHandler(EditValueChanged);
                txtDocDescription.EditValueChanged -= new EventHandler(EditValueChanged);
                dtDocPaymentDate.EditValueChanged -= new EventHandler(EditValueChanged);
                dtDocDate.EditValueChanged -= new EventHandler(EditValueChanged);
                cboxCurrency.EditValueChanged -= new EventHandler(EditValueChanged);
                cboxBudgetProject.EditValueChanged -= new EventHandler(EditValueChanged);
                cboxAccountPlan.EditValueChanged -= new EventHandler(EditValueChanged);

                cboxBudgetDep.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                cboxCompany.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                cboxPaymentType.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                cboxDebitArticle.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                cboxCurrency.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                treelistBudgetItem.CellValueChanged -= new DevExpress.XtraTreeList.CellValueChangedEventHandler(treelistBudgetItem_CellValueChanged);
                cboxBudgetProject.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                cboxAccountPlan.SelectedValueChanged -= new EventHandler(SelectedValueChanged);

                // теперь присвоим заявке нужные значения
                // валюта
                if (m_objBudgetDoc.Currency != null)
                {
                    cboxCurrency.Properties.Items.Clear();
                    cboxCurrency.Properties.Items.Add(m_objBudgetDoc.Currency.CurrencyCode);
                    cboxCurrency.SelectedItem = cboxCurrency.Properties.Items[0];
                }
                // примечание
                txtDocDescription.Text = m_objBudgetDoc.Description;
                // документальное основание
                txtDocBasis.Text = m_objBudgetDoc.DocBasis;
                // цель
                txtDocObjective.Text = m_objBudgetDoc.Objective;
                // получатель средств
                txtDocReceipt.Text = m_objBudgetDoc.Recipient;
                // тип расходов
                WriteBudgetExpenseType((m_objBudgetDoc.BudgetItem == null) ? null : m_objBudgetDoc.BudgetItem.BudgetExpenseType); 
                // срок платежа
                dtDocPaymentDate.DateTime = m_objBudgetDoc.PaymentDate;
                // дата документа
                dtDocDate.DateTime = m_objBudgetDoc.Date;
                // бюджетное подразделение
                if (m_objBudgetDoc.BudgetDep != null)
                {
                    cboxBudgetDep.Properties.Items.Clear();
                    cboxBudgetDep.Properties.Items.Add(m_objBudgetDoc.BudgetDep);
                    cboxBudgetDep.SelectedItem = cboxBudgetDep.Properties.Items[0];
                }
                // проект
                if( m_objBudgetDoc.BudgetProject != null )
                {
                    cboxBudgetProject.Properties.Items.Clear();
                    cboxBudgetProject.Properties.Items.Add( m_objBudgetDoc.BudgetProject );
                    cboxBudgetProject.SelectedItem =  ( ( cboxBudgetProject.Properties.Items.Count > 0 ) ? cboxBudgetProject.Properties.Items.Cast<CBudgetProject>().SingleOrDefault<CBudgetProject>( x=>x.uuidID.Equals(m_objBudgetDoc.BudgetProject.uuidID) ) : null );
                }
                // компания
                if (m_objBudgetDoc.Company != null)
                {
                    cboxCompany.Properties.Items.Clear();
                    if (m_DocStateVariant == enumDocStateVariant.SavedDocument)
                    {
                        cboxCompany.Properties.Items.AddRange(CCompany.GetCompanyList(m_objProfile).Where<ERP_Budget.Common.CCompany>(x => x.IsActive == true).ToList<ERP_Budget.Common.CCompany>());
                        cboxCompany.SelectedItem = ( ( cboxCompany.Properties.Items.Count > 0 ) ? cboxCompany.Properties.Items.Cast<CCompany>().SingleOrDefault<CCompany>( x=>x.uuidID.Equals(m_objBudgetDoc.Company.uuidID) ) : null );
                    }
                    else
                    {
                        cboxCompany.Properties.Items.Add(m_objBudgetDoc.Company);
                        cboxCompany.SelectedItem = cboxCompany.Properties.Items[0];
                    }
                }
                // форма оплаты
                if (m_objBudgetDoc.PaymentType != null)
                {
                    cboxPaymentType.Properties.Items.Clear();
                    cboxPaymentType.Properties.Items.Add(m_objBudgetDoc.PaymentType);
                    cboxPaymentType.SelectedItem = cboxPaymentType.Properties.Items[0];
                }
                // сумма заявки
                txtDocMoney.Value = System.Convert.ToDecimal(m_objBudgetDoc.Money);
                txtDocMoney.Properties.DisplayFormat.FormatString = "### ### ###.##";
                txtDocMoney.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                // сумма заявки в валюте бюджета
                txtDocMoneyBudgetCurrency.Text = System.String.Format("{0:N}", m_objBudgetDoc.MoneyAgree) + " " + ERP_Budget.Global.Consts.strCurrencyBudget;

                System.Boolean bShowRestMoney = ((m_DocStateVariant != enumDocStateVariant.ArjDocument) &&
                            ((m_strMainDynamicRight == ERP_Budget.Global.Consts.strDRManager) ||
                            (m_strMainDynamicRight == ERP_Budget.Global.Consts.strDRInspector) ||
                            (m_strMainDynamicRight == ERP_Budget.Global.Consts.strDRCoordinator)));

                if (m_objBudgetDoc.BudgetItem != null)
                {
                    // статья бюджета
                    cboxDebitArticle.Properties.Items.Clear();
                    cboxDebitArticle.Properties.Items.Add(m_objBudgetDoc.BudgetItem);
                    cboxDebitArticle.SelectedItem = cboxDebitArticle.Properties.Items[0];

                    // устанавливаем цвет
                    txtRestMoneyDebitArticle.Properties.Appearance.BackColor = (m_objBudgetDoc.BudgetItem.RestMoney < 0) ? System.Drawing.Color.Tomato : System.Drawing.Color.LightGreen;

                    // список подстатей бюджета
                    treelistBudgetItem.Nodes.Clear();
                    if (m_objBudgetDoc.Division == false)
                    {
                        treelistBudgetItem.CellValueChanged -= new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treelistBudgetItem_CellValueChanged);
                        if ((m_objBudgetDoc.BudgetItemList != null) && (m_objBudgetDoc.BudgetItemList.Count > 0))
                        {
                            if ((m_objBudgetDoc.BudgetItemList.Count == 1) &&
                                (m_objBudgetDoc.BudgetItem.Name == m_objBudgetDoc.BudgetItemList[0].Name) &&
                                ((m_objBudgetDoc.BudgetItem.BudgetItemNum + ".0") == m_objBudgetDoc.BudgetItemList[0].BudgetItemNum))
                            {
                                // статья по-умолчанию
                            }
                            else
                            {
                                foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in m_objBudgetDoc.BudgetItemList)
                                {
                                    if (objBudgetItem.ParentID.CompareTo(System.Guid.Empty) == 0) { continue; }
                                    DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                                    treelistBudgetItem.AppendNode(new object[] { true, 
                                        objBudgetItem.BudgetItemFullName, objBudgetItem.RestMoney, objBudgetItem.MoneyInBudgetDocCurrency, 
                                        objBudgetItem.MoneyInBudgetCurrency, objBudgetItem.DontChange, 
                                        ( ( objBudgetItem.BudgetExpenseType != null ) ? objBudgetItem.BudgetExpenseType.Name : "" ), 
                                    ( ( objBudgetItem.AccountPlan != null ) ? objBudgetItem.AccountPlan.CodeIn1C : System.String.Empty )}, null);
                                            objNode.Tag = objBudgetItem;
                                }
                            }
                        }
                    }

                    colCheck.OptionsColumn.AllowEdit = false;
                    colCheck.OptionsColumn.ReadOnly = true;
                    colCheck.OptionsColumn.AllowFocus = false;

                    colMoney.OptionsColumn.AllowEdit = false;
                    colMoney.OptionsColumn.ReadOnly = true;
                    colMoney.OptionsColumn.AllowFocus = false;

                    // остаток средств
                    m_objBudgetDoc.BudgetItem.RestMoney =
                            ERP_Budget.Common.CBudgetItem.GetParentBudgetItemBalans(m_objBudgetDoc.BudgetItem.uuidID,
                            this.m_objProfile);
                    if (bShowRestMoney == true)
                    {
                        // у пользователя есть доступ к остатку статьи,
                        // но если это внебюджетные расходы, то остаток мы не отображаем
                        bShowRestMoney = (m_objBudgetDoc.BudgetItem.OffExpenditures == false);
                        if ((bShowRestMoney == true) && (m_DocStateVariant == enumDocStateVariant.SavedDocument) 
                            && (m_objBudgetDoc.IsActive == true) && (m_objBudgetDoc.DocState != null))
                        {
                            // этому коварному пользователю по прежнему можно видеть остаток по статье
                            // у нас активный сохраненный документ, показывать остаток имеет смысл, если
                            // в данный момент пользователь совершает действия над заявкой
                            bShowRestMoney = m_bNeedEvent;
                        }
                    }
                    //txtRestMoneyDebitArticle.Visible = (m_objBudgetDoc.BudgetItem.OffExpenditures == false);
                    txtRestMoneyDebitArticle.Text = System.String.Format("{0:N}", m_objBudgetDoc.BudgetItem.RestMoney) + " " +
                        ERP_Budget.Global.Consts.strCurrencyBudget;

                    // план счетов
                    cboxAccountPlan.Properties.Items.Clear();
                    if (m_objBudgetDoc.AccountPlan != null)
                    {
                        cboxAccountPlan.Properties.Items.Add( m_objBudgetDoc.AccountPlan );
                    }
                    else
                    {
                        // запрашиваем счёт из статьи
                        if (m_objBudgetDoc.BudgetItem.AccountPlan != null)
                        {
                            cboxAccountPlan.Properties.Items.Add(m_objBudgetDoc.BudgetItem.AccountPlan);
                        }
                    }
                    cboxAccountPlan.SelectedItem = ((cboxAccountPlan.Properties.Items.Count > 0) ? cboxAccountPlan.Properties.Items.Cast<CAccountPlan>().SingleOrDefault<CAccountPlan>(x => x.uuidID.Equals(m_objBudgetDoc.AccountPlan.uuidID)) : null);

                }
                if (bShowRestMoney == false)
                {
                    colRestMoney.VisibleIndex = -1;
                    colMoneyBudget.VisibleIndex = -1;
                    //m_bNeedCheckBalance = false;
                    txtRestMoneyDebitArticle.Visible = false;
                }
                // прячем/отображаем список подстатей
                SetTreeListBudgetItemSize();

                // Изменяет фон элементов управления
                ChangeBackGrnd();

                // теперь нужно включить обработчики событий у элементов управления
                switch (m_ViewDocVariant)
                {
                    case enumViewDocVariant.NewDocument:
                        //txtDocMoney.EditValueChanged += new EventHandler(EditValueChanged);
                        txtDocReceipt.EditValueChanged += new EventHandler(EditValueChanged);
                        txtDocObjective.EditValueChanged += new EventHandler(EditValueChanged);
                        txtDocBasis.EditValueChanged += new EventHandler(EditValueChanged);
                        txtDocDescription.EditValueChanged += new EventHandler(EditValueChanged);
                        dtDocPaymentDate.EditValueChanged += new EventHandler(EditValueChanged);
                        dtDocDate.EditValueChanged += new EventHandler(EditValueChanged);
                        cboxCurrency.EditValueChanged += new EventHandler(EditValueChanged);
                        cboxBudgetDep.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxCompany.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxPaymentType.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxDebitArticle.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        treelistBudgetItem.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(treelistBudgetItem_CellValueChanged);
                        cboxCurrency.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxAccountPlan.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxBudgetProject.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        break;
                    case enumViewDocVariant.BlockControl:
                        txtDocReceipt.EditValueChanged += new EventHandler(EditValueChanged);
                        txtDocObjective.EditValueChanged += new EventHandler(EditValueChanged);
                        txtDocBasis.EditValueChanged += new EventHandler(EditValueChanged);
                        txtDocDescription.EditValueChanged += new EventHandler(EditValueChanged);
                        cboxCompany.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        dtDocPaymentDate.EditValueChanged += new EventHandler(EditValueChanged);
                        break;
                    default:
                        break;
                }


                bRet = true;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка синхронизации свойств объекта \"Заявка\" \nи значений в элементах управления.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }
        /// <summary>
        /// Присваивает элементам управления значения свойств объекта "Заявка"
        /// </summary>
        /// <returns>true - удачное завершение; false - ошибка</returns>
        private System.Boolean bCopyPropertiesToBudgetDocControls(ERP_Budget.Common.CBudgetDoc objSrcBudgetDoc)
        {
            System.Boolean bRet = false;
            if (m_objBudgetDoc == null) { return bRet; }
            try
            {
                m_objBudgetDoc.Division = false;
                // сумма заявки
                txtDocMoney.Properties.DisplayFormat.FormatString = "### ### ###.##";
                txtDocMoney.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                // примечание
                txtDocDescription.Text = m_objBudgetDoc.Description;
                // документальное основание
                txtDocBasis.Text = m_objBudgetDoc.DocBasis;
                // цель
                txtDocObjective.Text = m_objBudgetDoc.Objective;
                // получатель средств
                txtDocReceipt.Text = m_objBudgetDoc.Recipient;
                // дата платежа
                dtDocPaymentDate.DateTime = System.DateTime.Today;
                // дата документа
                dtDocDate.DateTime = System.DateTime.Today;

                m_objBudgetDoc.Date = dtDocDate.DateTime;
                m_objBudgetDoc.PaymentDate = dtDocPaymentDate.DateTime;
                // компания
                if( (m_objBudgetDoc.Company != null) && (cboxCompany.Properties.Items.Count > 0 ) )
                {
                    cboxCompany.SelectedItem = (cboxCompany.Properties.Items.Cast<CCompany>().SingleOrDefault<CCompany>(x=>x.uuidID.CompareTo(m_objBudgetDoc.Company.uuidID) == 0) );
                }
                // форма оплаты
                if( (m_objBudgetDoc.PaymentType != null) && (cboxPaymentType.Properties.Items.Count > 0 ) )
                {
                    cboxPaymentType.SelectedItem = (cboxPaymentType.Properties.Items.Cast<CPaymentType>().SingleOrDefault<CPaymentType>(x => x.uuidID.CompareTo(m_objBudgetDoc.PaymentType.uuidID) == 0));
                }
                // бюджетное подразделение
                if( ( m_objBudgetDoc.BudgetDep != null ) && ( cboxBudgetDep.Properties.Items.Count > 0 ) )
                {
                    cboxBudgetDep.SelectedItem = (cboxBudgetDep.Properties.Items.Cast<CBudgetDep>().SingleOrDefault<CBudgetDep>(x => x.uuidID.CompareTo(m_objBudgetDoc.BudgetDep.uuidID) == 0));
                }
                // валюта
                if( ( m_objBudgetDoc.Currency != null ) && ( cboxCurrency.Properties.Items.Count > 0 ) )
                {
                    cboxCurrency.SelectedItem = (cboxCurrency.Properties.Items.Cast<CCurrency>().SingleOrDefault<CCurrency>(x => x.uuidID.CompareTo(m_objBudgetDoc.Currency.uuidID) == 0 ));
                }
                if (objSrcBudgetDoc.BudgetItem != null)
                {
                    foreach (object objPopupBudgetItem in cboxDebitArticle.Properties.Items)
                    {
                        if (objPopupBudgetItem.GetType().ToString() == "System.String") { continue; }

                        if (((ERP_Budget.Common.CPopupBudgetItem)objPopupBudgetItem).ParentBudgetItem.BudgetItemFullName == objSrcBudgetDoc.BudgetItem.BudgetItemFullName)
                        {
                            cboxDebitArticle.SelectedItem = objPopupBudgetItem;
                            break;
                        }
                    }
                    // если статья выбрана, то можно заняться подстатьями и суммами
                    if (cboxDebitArticle.SelectedItem != null)
                    {
                        // после выбора статьи у нас должен был отрисоваться список подстатей
                        if ((treelistBudgetItem.Nodes.Count > 0) && (objSrcBudgetDoc.Division == false))
                        {
                            // пройдем по списку подстатей и поисчем для каждой узел, в котором пропишем суммы
                            foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in objSrcBudgetDoc.BudgetItemList)
                            {
                                if (objBudgetItem.ParentID.CompareTo(System.Guid.Empty) == 0) { continue; }

                                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                                {
                                    if (objNode.Tag == null) { continue; }
                                    ERP_Budget.Common.CBudgetItem objTagBudgetItem = (ERP_Budget.Common.CBudgetItem)objNode.Tag;
                                    if (objTagBudgetItem.BudgetItemFullName != objBudgetItem.BudgetItemFullName) { continue; }

                                    // подстатьи совпали
                                    System.Decimal MoneyBudgetCurrency = System.Convert.ToDecimal(objBudgetItem.MoneyInBudgetDocCurrency) * System.Convert.ToDecimal( GetCurrencyRate(txtDocMoney.CurrencyCode) );
                                    // пропишем значения в узле
                                    objNode.SetValue(colCheck, true);
                                    objNode.SetValue(colMoney, objBudgetItem.MoneyInBudgetDocCurrency);
                                    objNode.SetValue(colMoneyBudget, MoneyBudgetCurrency);
                                    // теперь добавим в бюджетный документ подстатью
                                    objTagBudgetItem.MoneyInBudgetCurrency = System.Convert.ToDouble(MoneyBudgetCurrency);
                                    objTagBudgetItem.MoneyInBudgetDocCurrency = objBudgetItem.MoneyInBudgetDocCurrency;
                                    m_objBudgetDoc.BudgetItemList.Add(objTagBudgetItem);

                                    break;
                                }
                            }
                            // пересчитаем сумму бюджетного документа
                            RecalcDocMoney();
                        }
                        else
                        {
                            // в дереве подстатей нет, пропишем сумму сразу в txtDocMoney
                            txtDocMoney.Value = System.Convert.ToDecimal(objSrcBudgetDoc.Money);
                            txtDocMoney_Validated(txtDocMoney, new EventArgs());
                            // остаток средств по статье
                            //CheckBalans();
                        }
                    }
                }
                CheckConstrtCompanyPayType();
                bRet = true;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "bCopyPropertiesToBudgetDocControls\n\nОшибка синхронизации свойств объекта \"Заявка\" \nи значений в элементах управления.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }
        /// <summary>
        /// Изменяет фон элементов управления
        /// </summary>
        private void ChangeBackGrnd()
        {
            try
            {
                System.Drawing.Color WarningColor = System.Drawing.Color.PapayaWhip;
                System.Drawing.Color NormalColor = System.Drawing.SystemColors.Window;
                if (m_DocStateVariant != enumDocStateVariant.ArjDocument)
                {
                    cboxBudgetDep.BackColor = (cboxBudgetDep.Text == "") ? WarningColor : NormalColor;
                    cboxCompany.BackColor = (cboxCompany.Text == "") ? WarningColor : NormalColor;
                    cboxPaymentType.BackColor = (cboxPaymentType.Text == "") ? WarningColor : NormalColor;
                    cboxDebitArticle.BackColor = (cboxDebitArticle.Text == "") ? WarningColor : NormalColor;
                    cboxCurrency.BackColor = (cboxCurrency.Text == "") ? WarningColor : NormalColor;
                    cboxAccountPlan.BackColor = (cboxAccountPlan.Text == "") ? WarningColor : NormalColor;
                    cboxBudgetProject.BackColor = (cboxBudgetProject.Text == "") ? WarningColor : NormalColor;
                    txtDocReceipt.BackColor = (txtDocReceipt.Text == "") ? WarningColor : NormalColor;
                    txtDocObjective.BackColor = (txtDocObjective.Text == "") ? WarningColor : NormalColor;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения фона элементов управления.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region Обработчики событий элементов управления
        /// <summary>
        /// Обработчик события, возникающего после изменения редактируемого значения в элементе управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_ViewDocVariant == enumViewDocVariant.Arj) { return; }
                if ((Control)sender == txtDocReceipt)
                {
                    // получатель платежа
                    this.m_objBudgetDoc.Recipient = txtDocReceipt.Text;
                }
                if ((Control)sender == txtDocObjective)
                {
                    // цель
                    m_objBudgetDoc.Objective = txtDocObjective.Text;
                }
                if ((Control)sender == txtDocBasis)
                {
                    // документальное обоснование
                    this.m_objBudgetDoc.DocBasis = txtDocBasis.Text;
                }
                if ((Control)sender == txtDocDescription)
                {
                    // примечание
                    this.m_objBudgetDoc.Description = txtDocDescription.Text;
                }
                if ((Control)sender == dtDocPaymentDate)
                {
                    // срок платежа
                    this.m_objBudgetDoc.PaymentDate = dtDocPaymentDate.DateTime;

                    // если мы поменяли дату, то нужно запросить курс валют на эту дату и пересчитать суммы в заявке
                    // будем это делать в том случае, если это новая заявка
                    if (m_ViewDocVariant == enumViewDocVariant.NewDocument)
                    {
                        LoadCurrencyRateList();
                        RecalcSumForChangeInCurrency();
                        cboxCurrency.ToolTip = GetCurrencyRateList();
                    }
                }
                if ((Control)sender == dtDocDate)
                {
                    // дата документа
                    this.m_objBudgetDoc.Date = dtDocDate.DateTime;
                }
                if ((Control)sender == cboxCurrency)
                {
                    RecalcSumForChangeInCurrency();
                    cboxCurrency.ToolTip = GetCurrencyRateList();
                }
                // меняем фон
                ChangeBackGrnd();
                // уведомляем мир о том, что свойсво заявки изменилось
                SimulateChangeBudgetDocPropertie(((Control)sender).Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции EditValueChanging.\nОбъект : " + ((Control)sender).Name + "\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((Control)sender == cboxBudgetDep)
                {
                    // бюджетное подразделение
                    if (cboxBudgetDep.SelectedItem.GetType() == typeof(ERP_Budget.Common.CBudgetDep))
                    {
                        m_objBudgetDoc.BudgetDep = (ERP_Budget.Common.CBudgetDep)cboxBudgetDep.SelectedItem;
                        // необходимо проверить динамическое право для данного подразделения
                        m_strMainDynamicRight = ERP_Budget.Common.CDynamicRight.GetMainDynamicRight(m_objProfile, m_objBudgetDoc.BudgetDep);

                        if (((m_strMainDynamicRight == ERP_Budget.Global.Consts.strDRManager) ||
                              (m_strMainDynamicRight == ERP_Budget.Global.Consts.strDRInspector) ||
                              (m_strMainDynamicRight == ERP_Budget.Global.Consts.strDRCoordinator)) == false)
                        {
                            txtRestMoneyDebitArticle.Visible = false;
                        }

                        // в случае изменения бюджетного подразделения, необходимо обновить список доступных проектов

                        m_objBudgetDoc.BudgetItem = null;
                        m_objBudgetDoc.BudgetItemList.Clear();
                        m_objBudgetDoc.BudgetProject = null;

                        RefreshBudgetProjectForBudgetDep( m_objBudgetDoc.BudgetDep );

                        //// обновляем список статей расходов
                        //System.Guid uuidBudgetProjectId = ((m_objBudgetDoc.BudgetProject != null) ? m_objBudgetDoc.BudgetProject.uuidID : System.Guid.Empty);
                        //System.Guid uuidBudgetDepId = ((m_objBudgetDoc.BudgetDep != null) ? m_objBudgetDoc.BudgetDep.uuidID : System.Guid.Empty);

                        //RefreshDebitArticleList(uuidBudgetDepId, uuidBudgetProjectId);
                    }
                }
                if ((Control)sender == cboxBudgetProject)
                {
                    m_objBudgetDoc.BudgetProject = ((cboxBudgetProject.SelectedItem != null) ? ((CBudgetProject)cboxBudgetProject.SelectedItem) : null);
                    
                    // обновляем список статей расходов
                    System.Guid uuidBudgetProjectId = ((m_objBudgetDoc.BudgetProject != null) ? m_objBudgetDoc.BudgetProject.uuidID : System.Guid.Empty);
                    System.Guid uuidBudgetDepId = ((m_objBudgetDoc.BudgetDep != null) ? m_objBudgetDoc.BudgetDep.uuidID : System.Guid.Empty);

                    RefreshDebitArticleList(uuidBudgetDepId, uuidBudgetProjectId);
                }
                if ((Control)sender == cboxAccountPlan)
                {
                    m_objBudgetDoc.AccountPlan = ((cboxAccountPlan.SelectedItem != null) ? ((CAccountPlan)cboxAccountPlan.SelectedItem) : null);
                }

                if ((Control)sender == cboxCompany)
                {
                    // компания
                    if (cboxCompany.SelectedItem.GetType() == typeof(ERP_Budget.Common.CCompany))
                    {
                        m_objBudgetDoc.Company = (ERP_Budget.Common.CCompany)cboxCompany.SelectedItem;
                    }
                    CheckConstrtCompanyPayType();
                }
                if ((Control)sender == cboxPaymentType)
                {
                    // форма оплаты
                    if (cboxPaymentType.SelectedItem.GetType() == typeof(ERP_Budget.Common.CPaymentType))
                    {
                        m_objBudgetDoc.PaymentType = (ERP_Budget.Common.CPaymentType)cboxPaymentType.SelectedItem;
                    }
                    CheckConstrtCompanyPayType();
                }
                if ((Control)sender == cboxDebitArticle)
                {
                    // статья расходов
                    if( ( cboxDebitArticle.SelectedItem != null ) && (cboxDebitArticle.SelectedItem.GetType() == typeof(ERP_Budget.Common.CPopupBudgetItem)))
                    {
                        ERP_Budget.Common.CPopupBudgetItem objPopupBudgetItem = (ERP_Budget.Common.CPopupBudgetItem)cboxDebitArticle.SelectedItem;

                        WriteBudgetExpenseType(objPopupBudgetItem.ParentBudgetItem.BudgetExpenseType);
                        m_objBudgetDoc.BudgetItem = objPopupBudgetItem.ParentBudgetItem;
                        
                        // счёт из плана счетов
                        RefreshAccounPlanForBudgetItem(m_objBudgetDoc.BudgetItem);

                        // обновляет список подстатей
                        RefreshChildDebitArticleList(objPopupBudgetItem);
                        if (treelistBudgetItem.Nodes.Count == 0)
                        {
                            // у статьи нет подстатей
                            if (m_objBudgetDoc.BudgetItemList == null)
                            {
                                m_objBudgetDoc.BudgetItemList = new List<CBudgetItem>();
                            }
                            else
                            {
                                m_objBudgetDoc.BudgetItemList.Clear();
                            }

                            // список подстатей пуст, но есть нюанс...
                            // в бюджетах с 2009 года для каждой статьи должна быть подстатья по умолчанию 
                            // с таким же названием как у статьи и номером + ".0"
                            // в видимый список подстатей мы ее не добавляем, но в m_objBudgetDoc.BudgetItemList добавиь нужно
                            foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in objPopupBudgetItem.ChlildBudgetItemList)
                            {
                                if (objBudgetItem.uuidID.CompareTo(m_objBudgetDoc.BudgetItem.uuidID) == 0) { continue; }
                                if ((objBudgetItem.Name == m_objBudgetDoc.BudgetItem.Name) &&
                                    (objBudgetItem.BudgetItemNum == (m_objBudgetDoc.BudgetItem.BudgetItemNum + ".0"))) 
                                {
                                    m_objBudgetDoc.BudgetItemList.Add(objBudgetItem);
                                    break;
                                }
                            }

                            if (m_objBudgetDoc.BudgetItemList.Count == 0)
                            {
                                // не удалось найти даже подстатью по-умолчанию
                                // значит это старый не модный бюджет
                                m_objBudgetDoc.BudgetItemList.Add(m_objBudgetDoc.BudgetItem);
                            }
                        }

                        // остаток средств по статье
                        CheckBalans();
                    }
                }
                if ((Control)sender == cboxCurrency)
                {
                    RecalcSumForChangeInCurrency();
                    cboxCurrency.ToolTip = GetCurrencyRateList();
                }
                // меняем фон
                ChangeBackGrnd();
                // уведомляем мир о том, что свойсво заявки изменилось
                SimulateChangeBudgetDocPropertie(((Control)sender).Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции SelectedValueChanged.\nОбъект : " + ((Control)sender).Name + "\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Пересчитывает суммы для вновь выбранной валюты
        /// </summary>
        private void RecalcSumForChangeInCurrency()
        {
            try
            {
                if (cboxCurrency.SelectedItem == null) { return; }
                m_objBudgetDoc.Currency = (ERP_Budget.Common.CCurrency)cboxCurrency.SelectedItem;

                txtDocMoney.CurrencyCode = m_objBudgetDoc.Currency.CurrencyCode;
                txtDocMoney.CurrencyCodeBudget = ERP_Budget.Global.Consts.strCurrencyBudget;
                txtDocMoney.CurrencyRate = (txtDocMoney.CurrencyCode == txtDocMoney.CurrencyCodeBudget) ? 1 : GetCurrencyRate(txtDocMoney.CurrencyCode);
                if (treelistBudgetItem.Nodes.Count == 0)
                {
                    txtDocMoney.Value = 0;
                    if (txtDocMoney.Text != "")
                    {
                        txtDocMoneyBudgetCurrency.Text = System.String.Format("{0:N}", txtDocMoney.GetValue()) + " " + txtDocMoney.CurrencyCodeBudget;
                    }
                }
                else
                {
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        if ((System.Boolean)objNode.GetValue(colCheck) == true)
                        {
                            RecalcNodeSum(objNode);
                        }
                    }
                    treelistBudgetItem.Enabled = (checkChildBudgetItem.Checked);
                }
                // пересмотреть верхний блок 2007.05.02
                if (txtDocMoney.Text != "")
                {
                    txtDocMoneyBudgetCurrency.Text = System.String.Format("{0:N}", txtDocMoney.GetValue()) + " " + txtDocMoney.CurrencyCodeBudget;
                }
                txtDocMoney.Enabled = ((txtDocMoney.CurrencyCode != "") && (this.m_bWriteFromChildList == false));
                colMoney.OptionsColumn.ReadOnly = (txtDocMoney.CurrencyCode == "");
                colMoney.OptionsColumn.AllowEdit = (txtDocMoney.CurrencyCode != "");
                // подсчет дефицита средств
                CheckBalans();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции RecalcSumForChangeInCurrency.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Список статей и подстатей
        /// <summary>
        /// Обновляет выпадающий список статей бюджета для выбранной служба
        /// </summary>
        /// <param name="uuidBudgetDepID">уи службы</param>
        /// <param name="uuidBudgetDepProjectID">уи проекта</param>
        private void RefreshDebitArticleList(System.Guid uuidBudgetDepID, System.Guid uuidBudgetDepProjectID)
        {
            try
            {
                // очищаем список статей
                treelistBudgetItem.Tag = null;
                cboxDebitArticle.Text = strLoadText;
                cboxDebitArticle.Refresh();
                cboxDebitArticle.Properties.Items.Clear();

                // план счетов
                cboxAccountPlan.Properties.Items.Clear();

                // очищаем список подстатей
                treelistBudgetItem.Nodes.Clear();
                txtDocMoney.Value = 0;
                txtDocMoney_Validated(txtDocMoney, new EventArgs());

                HideTreeListBudgetItem(true);

                if( uuidBudgetDepID.Equals( System.Guid.Empty ) || uuidBudgetDepProjectID.Equals( System.Guid.Empty ) ) { return; }

                System.String strErr = System.String.Empty;
                if ((m_objBudgetDoc.DocType.ValidBudgetTypeList == null) || (m_objBudgetDoc.DocType.ValidBudgetTypeList.Count == 0))
                {
                    m_objBudgetDoc.DocType.ValidBudgetTypeList = CBudgetTypeDataBaseModel.GetValidBudgetTypeList(m_objBudgetDoc.DocType.uuidID, m_objProfile, null, ref strErr);
                }
                if ((m_objBudgetDoc.DocType.ValidBudgetTypeList == null) || (m_objBudgetDoc.DocType.ValidBudgetTypeList.Count == 0))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show( "Для типа доукмента \"" + m_objBudgetDoc.DocType.Name + "\" не указан список доступных бюджетов.\nОбратитесь, пожалуйста, к разработчику.", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                    return;
                }
                // для выбранной службы запрашиваем список статей бюджета
                if (m_objBudgetDoc.LoadPopupBudgetItemList(m_objProfile, uuidBudgetDepID) == true)
                {
                    // фильтруем список статей по указанному проекту
                    m_objBudgetDoc.PopupBudgetItemList = m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => ((x.ParentBudgetItem.BudgetProject != null) && (x.ParentBudgetItem.BudgetProject.uuidID.Equals(uuidBudgetDepProjectID)))).ToList<CPopupBudgetItem>();

                    // фильтруем список статей по типу документа
                    List<CPopupBudgetItem> objPopupBudgetItemListFilter = new List<CPopupBudgetItem>();
                    List<CPopupBudgetItem> objPopupBudgetItemList = null;
                    foreach (CBudgetType objBudgetType in m_objBudgetDoc.DocType.ValidBudgetTypeList)
                    {
                        objPopupBudgetItemList = m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => ((x.ParentBudgetItem.BudgetType != null) && (x.ParentBudgetItem.BudgetType.uuidID.Equals(objBudgetType.uuidID)))).ToList<CPopupBudgetItem>();
                        if ((objPopupBudgetItemList != null) && (objPopupBudgetItemList.Count > 0))
                        {
                            objPopupBudgetItemListFilter.AddRange(objPopupBudgetItemList);
                        }
                    }
                    m_objBudgetDoc.PopupBudgetItemList = objPopupBudgetItemListFilter;
                    objPopupBudgetItemList = null;

                    if ((m_objBudgetDoc.PopupBudgetItemList != null) && (m_objBudgetDoc.PopupBudgetItemList.Count > 0))
                    {
                        // если в списке есть статьи из разных бюджетов, то нужно это обозначить,
                        // указав перед группой статей название бюджета
                        // если все статьи из одного бюджета, то его название не пишем
                        List<System.Guid> BudgetGUIDList = m_objBudgetDoc.PopupBudgetItemList.Select(x => x.ParentBudgetItem.BudgetGUID).Distinct().ToList<System.Guid>();

                        if (BudgetGUIDList != null)
                        {
                            if (BudgetGUIDList.Count > 1)
                            {
                                System.String strBudgetName = "";
                                foreach (System.Guid uuidBudgetId in BudgetGUIDList)
                                {
                                    strBudgetName = (m_objBudgetDoc.PopupBudgetItemList.First<CPopupBudgetItem>(x => x.ParentBudgetItem.BudgetGUID.Equals(uuidBudgetId))).ParentBudgetItem.BudgetName;
                                    cboxDebitArticle.Properties.Items.Add((String.Format("- {0}", strBudgetName)));

                                    cboxDebitArticle.Properties.Items.AddRange(m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => x.ParentBudgetItem.BudgetGUID.Equals(uuidBudgetId)).ToList<CPopupBudgetItem>());
                                }
                            }
                            else
                            {
                                cboxDebitArticle.Properties.Items.AddRange(m_objBudgetDoc.PopupBudgetItemList);
                            }
                        }

                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления выпадающего списка \"Статьи расходов\"\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                cboxDebitArticle.SelectedItem = null;
            }
            return;
        }
        /// <summary>
        /// Фильтрация списка статей для выбранного типа бюджетного документа
        /// </summary>
        public void RefreshDebitArticleListForNewBudgetDocType()
        {
            try
            {
                if (m_objBudgetDoc.DocType == null) { return; }
                // в том случае, если изменился тип бюджетного документа, 
                // необходимо проверить, какие бюджеты (типы бюджетов) ему назначены
                // в том случае, если статья не выбрана, то выпадающий список статей расходов обновляется методом RefreshDebitArticleList
                // если же статья выбрана, то необходимо проверить, можно ли её назначать документу
                // если да, то она остаётся в списке, если нет, то то выпадающий список статей расходов обновляется методом RefreshDebitArticleList

                // дополнительная проверка на то, что это новый и ещё не сохранённый документ
                if (m_DocStateVariant == enumDocStateVariant.NewDocument)
                {
                    System.String strErr = System.String.Empty;
                    System.Guid uuidBudgetProjectId = ((m_objBudgetDoc.BudgetProject != null) ? m_objBudgetDoc.BudgetProject.uuidID : System.Guid.Empty);
                    System.Guid uuidBudgetDepId = ((m_objBudgetDoc.BudgetDep != null) ? m_objBudgetDoc.BudgetDep.uuidID : System.Guid.Empty);

                    if ((m_objBudgetDoc.DocType.ValidBudgetTypeList == null) || (m_objBudgetDoc.DocType.ValidBudgetTypeList.Count == 0))
                    {
                        // загрузка списка допустимых типов бюджетов
                        m_objBudgetDoc.DocType.ValidBudgetTypeList = ERP_Budget.Common.CBudgetTypeDataBaseModel.GetValidBudgetTypeList(m_objBudgetDoc.DocType.uuidID, m_objProfile, null, ref strErr);
                    }
                    // если список доступных бюджетов пуст, то выпадающие списки статей должны быть пусты
                    if ((m_objBudgetDoc.DocType.ValidBudgetTypeList == null) || (m_objBudgetDoc.DocType.ValidBudgetTypeList.Count == 0))
                    {
                        cboxDebitArticle.SelectedItem = null;
                        cboxDebitArticle.Properties.Items.Clear();
                        m_objBudgetDoc.BudgetItem = null;
                        m_objBudgetDoc.BudgetItemList = null;
                        treelistBudgetItem.Nodes.Clear();
                        treelistBudgetItem.Tag = null;

                        return;
                    }

                    if (cboxDebitArticle.SelectedItem == null)
                    {
                        if ((m_objBudgetDoc != null) && (m_objBudgetDoc.BudgetItem != null))
                        {
                            m_objBudgetDoc.BudgetItem = null;
                            m_objBudgetDoc.BudgetItemList = null;
                            treelistBudgetItem.Nodes.Clear();
                            treelistBudgetItem.Tag = null;
                        }

                        // обновляем список статей расходов
                        RefreshDebitArticleList(uuidBudgetDepId, uuidBudgetProjectId);
                    }
                    else
                    {
                        // указана статья бюджета
                        CPopupBudgetItem objSelectedBudgetItem = (CPopupBudgetItem)cboxDebitArticle.SelectedItem;
                        if (m_objBudgetDoc.DocType.ValidBudgetTypeList.FirstOrDefault<CBudgetType>(x => x.uuidID.CompareTo(objSelectedBudgetItem.ParentBudgetItem.BudgetType.uuidID) == 0) == null)
                        {
                            // выбранная статья отсутствует в списке допустимых бюджетов
                            cboxDebitArticle.SelectedItem = null;
                            cboxDebitArticle.Properties.Items.Clear();
                            m_objBudgetDoc.BudgetItem = null;
                            m_objBudgetDoc.BudgetItemList = null;
                            treelistBudgetItem.Nodes.Clear();

                            // обновляем список статей расходов
                            RefreshDebitArticleList(uuidBudgetDepId, uuidBudgetProjectId);
                        }
                        else
                        {
                            // статья входит в список допустимых бюджетов
                            // необходимо загрузить новый список статей, но оставить текущую

                            // для выбранной службы запрашиваем список статей бюджета
                            if (m_objBudgetDoc.LoadPopupBudgetItemList(m_objProfile, m_objBudgetDoc.BudgetDep.uuidID) == true)
                            {
                                // фильтруем список статей по указанному проекту
                                m_objBudgetDoc.PopupBudgetItemList = m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => ((x.ParentBudgetItem.BudgetProject != null) && (x.ParentBudgetItem.BudgetProject.uuidID.Equals(m_objBudgetDoc.BudgetProject.uuidID)))).ToList<CPopupBudgetItem>();

                                // фильтруем список статей по типу документа
                                List<CPopupBudgetItem> objPopupBudgetItemListFilter = new List<CPopupBudgetItem>();
                                List<CPopupBudgetItem> objPopupBudgetItemList = null;
                                foreach (CBudgetType objBudgetType in m_objBudgetDoc.DocType.ValidBudgetTypeList)
                                {
                                    objPopupBudgetItemList = m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => ((x.ParentBudgetItem.BudgetType != null) && (x.ParentBudgetItem.BudgetType.uuidID.Equals(objBudgetType.uuidID)))).ToList<CPopupBudgetItem>();
                                    if ((objPopupBudgetItemList != null) && (objPopupBudgetItemList.Count > 0))
                                    {
                                        objPopupBudgetItemListFilter.AddRange(objPopupBudgetItemList);
                                    }
                                }
                                m_objBudgetDoc.PopupBudgetItemList = objPopupBudgetItemListFilter;
                                objPopupBudgetItemList = null;
                                objPopupBudgetItemListFilter = objPopupBudgetItemListFilter.Where<CPopupBudgetItem>(x => (x.ParentBudgetItem.uuidID.CompareTo(objSelectedBudgetItem.ParentBudgetItem.uuidID) != 0)).ToList<CPopupBudgetItem>();

                                // список, котрый необходимо удалить из cboxDebitArticle
                                List<CPopupBudgetItem> objPopupBudgetItemListsRC = new List<CPopupBudgetItem>();

                                for (System.Int32 i = 0; i < cboxDebitArticle.Properties.Items.Count; i++)
                                {
                                    if (cboxDebitArticle.Properties.Items[i].GetType().Name == "CPopupBudgetItem")
                                    {
                                        objPopupBudgetItemListsRC.Add((CPopupBudgetItem)cboxDebitArticle.Properties.Items[i]);
                                    }
                                }

                                //List<CPopupBudgetItem> objPopupBudgetItemListsRC = cboxDebitArticle.Properties.Items.Cast<CPopupBudgetItem>().ToList<CPopupBudgetItem>();
                                //objPopupBudgetItemListsRC = objPopupBudgetItemListsRC.Where<CPopupBudgetItem>(x => (x.ParentBudgetItem.uuidID.CompareTo(objSelectedBudgetItem.ParentBudgetItem.uuidID) != 0)).ToList<CPopupBudgetItem>();

                                foreach (CPopupBudgetItem objItem in objPopupBudgetItemListsRC)
                                {
                                    cboxDebitArticle.Properties.Items.Remove(objItem);
                                }

                                cboxDebitArticle.Properties.Items.AddRange(objPopupBudgetItemListFilter);
                            
                            }

                        }

                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "RefreshDebitArticleListForNewBudgetDocType\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        
        /// <summary>
        /// Обновляет список подстатей для заданной статьи бюджета
        /// </summary>
        /// <param name="objPopupBudgetItem">содержит список дочерних статей бюджета</param>
        private void RefreshChildDebitArticleList(ERP_Budget.Common.CPopupBudgetItem objPopupBudgetItem)
        {
            try
            {
                // очищаем список
                treelistBudgetItem.Nodes.Clear();

                if ((m_objBudgetDoc.BudgetItem == null) || (objPopupBudgetItem == null))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка обновления списка подстатей расходов.\nНе удалось получить информацию о статье бюджета.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in objPopupBudgetItem.ChlildBudgetItemList)
                    {
                        if (objBudgetItem.uuidID.CompareTo(m_objBudgetDoc.BudgetItem.uuidID) == 0) { continue; }
                        if (objPopupBudgetItem.ChlildBudgetItemList.Count == 1)
                        {
                            // ! если название подстатьи совпадает с названием статьи и номер ее = № статьи + .0,
                            // то мы не добавляем такую статью в список
                            if ((objBudgetItem.Name == m_objBudgetDoc.BudgetItem.Name) &&
                                (objBudgetItem.BudgetItemNum == (m_objBudgetDoc.BudgetItem.BudgetItemNum + ".0"))) { continue; }
                        }

                        DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                                treelistBudgetItem.AppendNode(new object[] { false, 
                                objBudgetItem.BudgetItemFullName, objBudgetItem.RestMoney, 0, 0, objBudgetItem.DontChange, 
                                ( ( objBudgetItem.BudgetExpenseType != null ) ? objBudgetItem.BudgetExpenseType.Name : "" ),
                                ( ( objBudgetItem.AccountPlan != null ) ? objBudgetItem.AccountPlan.CodeIn1C : System.String.Empty )}, null);
                        objNode.Tag = objBudgetItem;
                    }
                    txtDocMoney.Value = 0;
                    txtDocMoney.Enabled = ((m_objBudgetDoc.Currency != null) && (treelistBudgetItem.Nodes.Count == 0));
                    txtDocMoney_Validated(txtDocMoney, new EventArgs());
                }
                if (treelistBudgetItem.Nodes.Count > 0)
                {
                    checkChildBudgetItem.EditValueChanged -= new EventHandler(this.checkChildBudgetItem_EditValueChanged);
                    checkChildBudgetItem.Checked = true;
                    checkChildBudgetItem.EditValueChanged += new EventHandler(this.checkChildBudgetItem_EditValueChanged);
                    this.m_bWriteFromChildList = true;
                    treelistBudgetItem.Enabled = (cboxCurrency.SelectedItem != null);
                }
                else
                {
                    m_bWriteFromChildList = false;
                }
                SetTreeListBudgetItemSize();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления списка подстатей расходов.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        /// <summary>
        /// Обновляет список доступных проектов для указанного бюджетного подразделения
        /// </summary>
        /// <param name="objBudgetDep">бюджетное подразделение</param>
        private void RefreshBudgetProjectForBudgetDep(CBudgetDep objBudgetDep)
        {
            try
            {
                cboxBudgetProject.Properties.Items.Clear();
                System.String strErr = "";

                if (objBudgetDep == null) { cboxBudgetProject.Properties.Items.Clear(); }
                else
                {
                    List<CBudgetProject> objBudgetProjectlist = CBudgetProjectDataBaseModel.GetBudgetProjectListForBudgetDepInDocument(m_objProfile, null, objBudgetDep.uuidID, dtDocDate.DateTime, ref strErr);
                    if( (objBudgetProjectlist != null) && (objBudgetProjectlist.Count > 0) )
                    {
                        cboxBudgetProject.Properties.Items.AddRange( objBudgetProjectlist );
                        cboxBudgetProject.SelectedItem = cboxBudgetProject.Properties.Items[0];
                    }
                    else if (strErr.Length > 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Ошибка обновления списка проектов.\nТекст ошибки: " + strErr, "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления списка проектов.\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        /// <summary>
        /// Устанавливает в элементе управления значение счёта
        /// </summary>
        /// <param name="objBudgetItem">Статья бюджета</param>
        private void RefreshAccounPlanForBudgetItem(CBudgetItem objBudgetItem)
        {
            try
            {
                if (objBudgetItem.AccountPlan == null) 
                {
                    cboxAccountPlan.SelectedItem = null;
                    cboxAccountPlan.Properties.Items.Clear(); 
                }
                else
                {
                    if( ( cboxAccountPlan.SelectedItem == null) || ( ((CAccountPlan)cboxAccountPlan.SelectedItem).uuidID.Equals( objBudgetItem.AccountPlan.uuidID ) == false ) )
                    {
                        // счёт не выбран или он не соответствует счёту статьи
                        cboxAccountPlan.Properties.Items.Clear();
                        cboxAccountPlan.Properties.Items.Add( objBudgetItem.AccountPlan );
                        cboxAccountPlan.SelectedItem = cboxAccountPlan.Properties.Items[0];
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления списка счетов.\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void cboxDebitArticle_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if( (m_ViewDocVariant == enumViewDocVariant.NewDocument) && ( e.NewValue != null ) )
                {
                    if (e.NewValue.GetType() == typeof(System.String))
                    {
                        e.Cancel = !(((System.String)e.NewValue == strLoadText) || ((System.String)e.NewValue == ""));
                        return;
                    }
                    else if (e.NewValue.GetType() == typeof(ERP_Budget.Common.CPopupBudgetItem))
                    {
                        e.Cancel = (((ERP_Budget.Common.CPopupBudgetItem)e.NewValue).ParentBudgetItem.BudgetItemDescription == strLblBudgetForPopupArticleList );
                                                                                                                                
                        return;
                    }
                    e.Cancel = (e.NewValue.GetType() != typeof(ERP_Budget.Common.CPopupBudgetItem));
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка проверки выбранной статьи расходов.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        /// <summary>
        /// Пересчитывает сумму в валюте бюджета в узле
        /// </summary>
        /// <param name="objNode">узел с подстатьей бюджета</param>
        private void RecalcNodeSum(DevExpress.XtraTreeList.Nodes.TreeListNode objNode)
        {
            try
            {
                System.Decimal Money = System.Convert.ToDecimal(objNode.GetValue(colMoney));
                // сумма в валюте бюджета
                System.Decimal MoneyBudgetCurrency = Money * System.Convert.ToDecimal(GetCurrencyRate(txtDocMoney.CurrencyCode));
                // прописываем поллученное значение в столбец "Сумма, EUR"
                objNode.SetValue(colMoneyBudget, MoneyBudgetCurrency);
                // и тут же нам нужно внести изменения в список подстатей
                SetBudgetItemList(colMoney, objNode);
                // пересчитаем сумму бюджетного документа
                RecalcDocMoney();
 
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка пересчета суммы.\nСтатья: " +
                (System.String)objNode.GetValue(colBudgetItemName) + ".\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void checkChildBudgetItem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (treelistBudgetItem.Nodes.Count == 0) { return; }
                System.Boolean bChecked = checkChildBudgetItem.Checked;
                this.Cursor = Cursors.WaitCursor;
                this.tlaypnlDemand_3.SuspendLayout();

                if (bChecked == true)
                {
                    this.m_bWriteFromChildList = true;
                    m_objBudgetDoc.Division = false;
                    // заблокируем возможность менять сумму по всей родительской статье
                    txtDocMoney.Value = 0;
                    txtDocMoney.Properties.ReadOnly = true;

                    // сбросим суммы во всех узлах
                    m_objBudgetDoc.BudgetItemList.Clear();
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        objNode.SetValue(colCheck, false);
                        objNode.SetValue(colMoney, 0);
                        objNode.SetValue(colMoneyBudget, 0);
                    }

                    treelistBudgetItem.Enabled = true;
                    treelistBudgetItem.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treelistBudgetItem_CellValueChanged);
                }
                else
                {
                    this.m_bWriteFromChildList = false;
                    m_objBudgetDoc.Division = true;
                    // сумма в txtDocMoney меняется напрямую
                    // если в списке подстатей есть какие-то суммы, то мы их обнулим
                    treelistBudgetItem.CellValueChanged -= new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treelistBudgetItem_CellValueChanged);
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        objNode.SetValue(colCheck, false);
                        objNode.SetValue(colMoney, 0);
                        objNode.SetValue(colMoneyBudget, 0);
                    }
                    m_objBudgetDoc.BudgetItemList.Clear();
                    m_objBudgetDoc.BudgetItemList.Add(m_objBudgetDoc.BudgetItem);

                    treelistBudgetItem.Enabled = false;
                    txtDocMoney.Properties.ReadOnly = false;
                    txtDocMoney.Enabled = true;
                    txtDocMoney.Value = 0;
                }
                txtDocMoney_Validated(txtDocMoney, new EventArgs());
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения свойства \"Вкл.\"\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.tlaypnlDemand_3.ResumeLayout(false);
                this.Cursor = Cursors.Default;
            }
            return;
        }
        private void treelistBudgetItem_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
           
        }

        private void treelistBudgetItem_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    // если меняется значение в столбце "Сумма", то пересчитаем значение в столбце "Сумма, EUR"
                    if (e.Column == colMoney)
                    {
                        System.Decimal Money = System.Convert.ToDecimal(e.Value);
                        // сумма в валюте бюджета
                        System.Decimal MoneyBudgetCurrency = Money * System.Convert.ToDecimal(GetCurrencyRate(txtDocMoney.CurrencyCode));
                        // прописываем поллученное значение в столбец "Сумма, EUR"
                        e.Node.SetValue(colMoneyBudget, MoneyBudgetCurrency);
                    }
                    SetBudgetItemList(e.Column, e.Node);
                    // пересчитаем сумму бюджетного документа
                    RecalcDocMoney();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения значения в списке подстатей.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void SetBudgetItemList(DevExpress.XtraTreeList.Columns.TreeListColumn objColumn,
            DevExpress.XtraTreeList.Nodes.TreeListNode objNode)
        {
            try
            {
                if (objColumn == colMoney)
                {
                    ERP_Budget.Common.CBudgetItem objBudgetItemSelect = (ERP_Budget.Common.CBudgetItem)objNode.Tag;
                    foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in m_objBudgetDoc.BudgetItemList)
                    {
                        if (objBudgetItem.uuidID.CompareTo(objBudgetItemSelect.uuidID) == 0)
                        {
                            objBudgetItem.MoneyInBudgetCurrency = System.Convert.ToDouble(objNode.GetValue(colMoneyBudget));
                            objBudgetItem.MoneyInBudgetDocCurrency = System.Convert.ToDouble(objNode.GetValue(colMoney));
                            if (this.m_ViewDocVariant == enumViewDocVariant.NewDocument)
                            {
                                if ((System.Convert.ToDouble(objNode.GetValue(colRestMoney)) - objBudgetItem.MoneyInBudgetCurrency) < 0)
                                {
                                    objBudgetItem.IsDefficit = true;
                                }
                                else
                                {
                                    objBudgetItem.IsDefficit = false;
                                }
                            }
                            break;
                        }
                    }
                }
                if (objColumn == colCheck)
                {
                    this.Cursor = Cursors.WaitCursor;
                    m_objBudgetDoc.BudgetItemList.Clear();
                    if ((checkChildBudgetItem.Checked == true) && (treelistBudgetItem.Nodes.Count > 0))
                    {
                        foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objectNode in treelistBudgetItem.Nodes)
                        {
                            if (((System.Boolean)objectNode.GetValue(colCheck)) &&
                                //(System.Convert.ToDouble(objectNode.GetValue(colMoneyBudget)) > 0) &&
                                (objectNode.Tag != null))
                            {
                                // эта подстатья выбрана и сумма не нулевая
                                ERP_Budget.Common.CBudgetItem objBudgetItem = (ERP_Budget.Common.CBudgetItem)objectNode.Tag;
                                objBudgetItem.MoneyInBudgetCurrency = System.Convert.ToDouble(objectNode.GetValue(colMoneyBudget));
                                objBudgetItem.MoneyInBudgetDocCurrency = System.Convert.ToDouble(objectNode.GetValue(colMoney));

                                if (this.m_ViewDocVariant == enumViewDocVariant.NewDocument)
                                {
                                    if ((System.Convert.ToDouble(objectNode.GetValue(colRestMoney)) - objBudgetItem.MoneyInBudgetCurrency) < 0)
                                    {
                                        objBudgetItem.IsDefficit = true;
                                    }
                                    else
                                    {
                                        objBudgetItem.IsDefficit = false;
                                    }
                                }

                                this.m_objBudgetDoc.BudgetItemList.Add(objBudgetItem);
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                }

                if ((m_ViewDocVariant == enumViewDocVariant.NewDocument) && (m_objBudgetDoc.BudgetItemList != null) && (m_objBudgetDoc.BudgetItemList.Count > 1))
                {
                    System.Int32 iOkCount = 0;
                    System.Int32 iCancelCount = 0;

                    foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in m_objBudgetDoc.BudgetItemList)
                    {
                        if (objBudgetItem.IsDefficit == true) { iCancelCount++; }
                        else { iOkCount++; }
                    }

                    if (((iOkCount == 0) || (iCancelCount == 0)) == false)
                    {
                        ShowHideWarningPnl(true, Color.Red, "Внимание!", "В документе не должно быть подстатей с положительным и отрицательным остатком!");
                    }
                    else
                    {
                        ShowHideWarningPnl(false, Color.Black, "", "");
                    }

                }
                else
                {
                    ShowHideWarningPnl(false, Color.Black, "", "");
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "SetBudgetItemList.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Пересчитывает сумму документа на основании сумм подстатей
        /// </summary>
        private void RecalcDocMoney()
        {
            try
            {
                if (treelistBudgetItem.Nodes.Count == 0) { return; }
                System.Decimal SumDocMoney = 0;
                if (txtDocMoney.CurrencyCode == "")
                {
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        objNode.SetValue(colMoney, 0);
                    }
                }
                else
                {
                    // подсчитаем сумму
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        if ((System.Boolean)objNode.GetValue(colCheck))
                        {
                            SumDocMoney += System.Convert.ToDecimal(objNode.GetValue(colMoney));
                        }
                    }
                }

                txtDocMoney.Value = SumDocMoney;
                txtDocMoney_Validated(txtDocMoney, new EventArgs());
                // остаток средств по статье
                CheckBalans();

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка подсчета суммы бюджетного документа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Устанавливает размеры дерева подстатей расходов
        /// </summary>
        private void SetTreeListBudgetItemSize()
        {
            try
            {
                //если список подстатей пуст, то прячем treelistBudgetItem
                this.tlaypnlDemand_3.SuspendLayout();

                if (treelistBudgetItem.Nodes.Count > 0)
                {
                    tlaypnlDemand_3.RowStyles[0].SizeType = SizeType.Absolute;
                    tlaypnlDemand_3.RowStyles[4].SizeType = SizeType.Absolute;

                    tlaypnlDemand_3.RowStyles[0].Height = 0;
                    tlaypnlDemand_3.RowStyles[4].Height = 0;

                    tlaypnlDemand_3.RowStyles[0].SizeType = SizeType.Percent;
                    tlaypnlDemand_3.RowStyles[4].SizeType = SizeType.Percent;

                    tlaypnlDemand_3.RowStyles[0].Height = 70;
                    tlaypnlDemand_3.RowStyles[4].Height = 30;
                }
                else
                {
                    tlaypnlDemand_3.RowStyles[0].SizeType = SizeType.Absolute;
                    tlaypnlDemand_3.RowStyles[0].Height = 0;
                    tlaypnlDemand_3.RowStyles[4].SizeType = SizeType.Percent;
                    tlaypnlDemand_3.RowStyles[4].Height = 100;
                }

                ((System.ComponentModel.ISupportInitialize)(this.checkChildBudgetItem.Properties)).BeginInit();

                this.checkChildBudgetItem.Visible = (treelistBudgetItem.Nodes.Count > 0);

                System.Boolean bVisibleCheck = true;
                System.Boolean bVisibleBudgetItemName = true;
                System.Boolean bVisibleRestMoney = false;
                System.Boolean bVisibleMoney = true;
                System.Boolean bVisibleMoneyBudget = true;
                System.Boolean bVisibleDontChange = false;


                // прячем/отображаем столбцы в списке подстатей
                if (m_objBudgetDoc.IsActive == false)
                {
                    bVisibleRestMoney = false;
                    bVisibleMoneyBudget = false;
                }
                else
                {
                    if (m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRInitiator) ||
                        m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCashier))
                    {
                        // обычному инициатору или кассиру не стоит видеть остаток
                        bVisibleRestMoney = false;
                    }
                    else
                    {
                        System.Boolean bManager = m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRManager);
                        if (bManager == true)
                        {
                            if (m_objBudgetDoc.BudgetDep != null)
                            {
                                if (m_objBudgetDoc.BudgetDep.Manager.ulUniXPID == m_objProfile.m_nSQLUserID)
                                {
                                    bVisibleRestMoney = true;
                                }
                            }
                        }
                        else
                        {
                            bVisibleRestMoney = true;
                        }
                    }
                }

                treelistBudgetItem.Columns[colCheck.FieldName].VisibleIndex = 0;
                treelistBudgetItem.Columns[colBudgetItemName.FieldName].VisibleIndex = 1;
                treelistBudgetItem.Columns[colRestMoney.FieldName].VisibleIndex = 2;
                treelistBudgetItem.Columns[colMoney.FieldName].VisibleIndex = 3;
                treelistBudgetItem.Columns[colMoneyBudget.FieldName].VisibleIndex = 4;
                treelistBudgetItem.Columns[colDontChange.FieldName].VisibleIndex = 5;
                treelistBudgetItem.Columns[colBudgetExpenseTypeName.FieldName].VisibleIndex = 6;
                treelistBudgetItem.Columns[colAccountPlan.FieldName].VisibleIndex = 7;

                treelistBudgetItem.Columns[colCheck.FieldName].Visible = bVisibleCheck;
                treelistBudgetItem.Columns[colBudgetItemName.FieldName].Visible = bVisibleBudgetItemName;
                treelistBudgetItem.Columns[colRestMoney.FieldName].Visible = bVisibleRestMoney;
                treelistBudgetItem.Columns[colMoney.FieldName].Visible = bVisibleMoney;
                treelistBudgetItem.Columns[colMoneyBudget.FieldName].Visible = bVisibleMoneyBudget;
                treelistBudgetItem.Columns[colDontChange.FieldName].Visible = bVisibleDontChange;


                ((System.ComponentModel.ISupportInitialize)(this.checkChildBudgetItem.Properties)).EndInit();

                this.tlaypnlDemand_3.ResumeLayout(false);


                this.tlaypnlDemand_3.Refresh();
                this.Size = new Size((this.Size.Width + 1), this.Size.Height);
                this.Refresh();

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения размеров дерева подстатей расходов.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Прячет список подстатей
        /// </summary>
        private void HideTreeListBudgetItem(System.Boolean bForced)
        {
            try
            {
                if (bForced == true)
                {
                    this.tlaypnlDemand_3.SuspendLayout();

                    tlaypnlDemand_3.RowStyles[4].Height = 100;
                    tlaypnlDemand_3.RowStyles[0].Height = 0;

                    ((System.ComponentModel.ISupportInitialize)(this.checkChildBudgetItem.Properties)).BeginInit();
                    this.checkChildBudgetItem.Visible = false;
                    txtDocMoney.Enabled = (m_objBudgetDoc.Currency != null);
                    this.tlaypnlDemand_3.ResumeLayout(false);
                    ((System.ComponentModel.ISupportInitialize)(this.checkChildBudgetItem.Properties)).EndInit();
                }
                else
                {
                    if (this.m_objBudgetDoc.Division == true)
                    {
                        // !!!! if (this.m_objViewDocVariantCondition.DynamicRight.Name != ERP_Budget.Global.Consts.strDRManager)
                        //{
                        this.tlaypnlDemand_3.SuspendLayout();

                        tlaypnlDemand_3.RowStyles[0].Height = 0;
                        tlaypnlDemand_3.RowStyles[4].Height = 100;
                        this.checkChildBudgetItem.Visible = false;

                        this.tlaypnlDemand_3.ResumeLayout(false);
                        //}
                    }
                }
                this.Size = new Size((this.Size.Width + 1), this.Size.Height);
                this.Refresh();
                //this.Update();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения размеров дерева подстатей расходов.\nHideTreeListBudgetItem\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                // прячем/отображаем столбцы в списке подстатей
                if (this.m_objBudgetDoc.IsActive == false)
                {
                    colRestMoney.Visible = false;
                    colMoneyBudget.Visible = false;
                }
                else
                {
                    if (this.m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRInitiator) ||
                        this.m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCashier))
                    {
                        colRestMoney.Visible = false;
                    }
                    else
                    {
                        colRestMoney.Visible = true;
                    }
                }
                colDontChange.Visible = false;
                colCheck.Visible = true;
                colBudgetItemName.Visible = true;
                colMoney.Visible = true;
                colMoneyBudget.Visible = true;

                colCheck.VisibleIndex = 0;
                colBudgetItemName.VisibleIndex = 1;
            }
            return;
        }
        #endregion

        #region SetFocus
        public void SetFocus()
        {
            if (cboxBudgetDep.Enabled == true)
            {
                cboxBudgetDep.Focus();
            }
        }
        #endregion

        //Открытие документа 

        #region ReorganizeDocSum
        /// <summary>
        /// Распределяет сумму документа по подстатьям
        /// </summary>
        public System.Boolean ReorganizeDocSum()
        {
            System.Boolean bRet = false;
            try
            {
                // если нужно размазать деньги по всем подстатьям, то делаем следующее
                if (m_objBudgetDoc.Division == true)
                {
                    System.Int32 iChildCount = treelistBudgetItem.Nodes.Count;
                    if (iChildCount > 0)
                    {
                        System.Double MoneyInBudgetCurrency = System.Convert.ToDouble(txtDocMoney.GetValue());
                        System.Double MoneyInBudgetDocCurrency = System.Convert.ToDouble(txtDocMoney.Value);
                        m_objBudgetDoc.BudgetItemList.Clear();
                        foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                        {
                            if (objNode.Tag == null) { continue; }
                            ERP_Budget.Common.CBudgetItem objBudgetItem = (ERP_Budget.Common.CBudgetItem)objNode.Tag;
                            if (objBudgetItem.RestMoney == 0) { continue; }
                            objBudgetItem.MoneyInBudgetCurrency = (objBudgetItem.RestMoney / m_objBudgetDoc.BudgetItem.RestMoney) * m_objBudgetDoc.MoneyAgree;
                            objBudgetItem.MoneyInBudgetDocCurrency = (objBudgetItem.RestMoney / m_objBudgetDoc.BudgetItem.RestMoney) * m_objBudgetDoc.Money;
                            m_objBudgetDoc.BudgetItemList.Add(objBudgetItem);
                        }
                        bRet = true;
                    }
                    else
                    {
                        bRet = false;
                    }
                }
            }
            catch (System.Exception f)
            {
                bRet = false;
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка распределения суммы по подстатьям\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bRet;
        }
        #endregion

        #region Курс валюты
        /// <summary>
        /// Возвращает уникальный идентификатор валюты по ее коду 
        /// </summary>
        /// <param name="strCurrencyCode">код валюты</param>
        /// <returns>уникальный идентификатор валюты</returns>
        private System.Guid GetCurrencyIDByCode(System.String strCurrencyCode)
        {
            System.Guid uuidRet = System.Guid.Empty;
            try
            {
                for (System.Int32 i = 0; i < cboxCurrency.Properties.Items.Count; i++)
                {
                    ERP_Budget.Common.CCurrency objCurrency = (ERP_Budget.Common.CCurrency)cboxCurrency.Properties.Items[i];
                    if (objCurrency.CurrencyCode == strCurrencyCode)
                    {
                        uuidRet = objCurrency.uuidID;
                        break;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка поиска идентификатора валюты по коду валюты\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return uuidRet;
        }
        /// <summary>
        /// Обновляет список курсов валют на сегодняшний день
        /// </summary>
        private void LoadCurrencyRateList()
        {
            try
            {
                this.m_objCurrencyRateList = new List<ERP_Budget.Common.CCurrencyRateItem>();
                m_objCurrencyRateListForDivision = new List<ERP_Budget.Common.CCurrencyRateItem>();

                // 2009.04.20
                // т.к. срок платежа могут менять все при создании заявки, а именно на эту дату мы хотим ориентироваться
                // при оформлении коротких заявок и оплаты (курс на дату оплаты), то 
                // для бухгалтера и кассира мы будем загружать курс на дату оплаты, 
                // а для всех остальных на текущую дату
                System.Boolean bUsePaymentDate = ( (m_objProfile.GetClientsRight().GetState( ERP_Budget.Global.Consts.strDRCashier ) == true) || 
                    (m_objProfile.GetClientsRight().GetState( ERP_Budget.Global.Consts.strDRAccountant ) == true));

                System.DateTime CurrRateDate = ( bUsePaymentDate == true ) ? m_objBudgetDoc.PaymentDate : System.DateTime.Today;

                System.Collections.Generic.List<ERP_Budget.Common.CCurrencyRateItem> objCurrencyRateList =
                    ERP_Budget.Common.CCurrencyRateItem.GetCurrencyRateList(m_objProfile, CurrRateDate,
                    GetCurrencyIDByCode(ERP_Budget.Global.Consts.strCurrencyBudget));

                if ((objCurrencyRateList != null) && (objCurrencyRateList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CCurrencyRateItem objCurrencyRateItem in objCurrencyRateList)
                    {
                        this.m_objCurrencyRateList.Add(objCurrencyRateItem);
                    }
                    objCurrencyRateList = null;
                }

                ERP_Budget.Common.CCurrencyRateItem objCurrencyRateItemSrc = new ERP_Budget.Common.CCurrencyRateItem();
                ERP_Budget.Common.CBaseList<ERP_Budget.Common.CCurrencyRateItem> objCurrencyRateListSRC = objCurrencyRateItemSrc.GetCurrencyRateList(m_objProfile, new System.DateTime(CurrRateDate.Year, CurrRateDate.Month, CurrRateDate.Day), new System.DateTime(CurrRateDate.Year, CurrRateDate.Month, CurrRateDate.Day));
                if (objCurrencyRateListSRC != null)
                {
                    for (System.Int32 i = 0; i < objCurrencyRateListSRC.GetCountItems(); i++)
                    {
                        m_objCurrencyRateListForDivision.Add(objCurrencyRateListSRC.GetByIndex(i));
                    }
                }
                objCurrencyRateListSRC = null;
                objCurrencyRateItemSrc = null;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка загрузки списка курсов валют\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Возвращает курс валюты strCorrencyCode по отношению к валюте ERP_Budget.Global.Consts.strCurrencyBudget
        /// </summary>
        /// <param name="strCorrencyCode">валюта</param>
        /// <returns>курс</returns>
        private System.Decimal GetCurrencyRate(System.String strCorrencyCode)
        {
            if (strCorrencyCode == ERP_Budget.Global.Consts.strCurrencyBudget) { return 1; }

            System.Decimal dRet = 0;
            try
            {
                foreach (ERP_Budget.Common.CCurrencyRateItem objCurrencyRateItem in this.m_objCurrencyRateList)
                {
                    if ((objCurrencyRateItem.CurrencyIn.CurrencyCode == strCorrencyCode) &&
                        (objCurrencyRateItem.CurrencyOut.CurrencyCode == ERP_Budget.Global.Consts.strCurrencyBudget))
                    {
                        dRet = objCurrencyRateItem.Value;
                        break;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка поиска курса валют\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return dRet;
        }
        /// <summary>
        /// Возвращает строку с курсами валют
        /// </summary>
        /// <returns>строка с курсами валют</returns>
        private System.String GetCurrencyRateList()
        {
            System.String strRet = "";
            try
            {
                if (this.m_objCurrencyRateList == null) { return strRet; }
                if (this.m_objCurrencyRateList.Count > 0)
                {
                    //strRet = this.m_objCurrencyRateList[0].Date.ToShortDateString();
                    strRet = this.m_objCurrencyRateListForDivision[0].Date.ToShortDateString();
                }
                //foreach (ERP_Budget.Common.CCurrencyRateItem objCurrencyRateItem in this.m_objCurrencyRateList)
                //{
                //    if (objCurrencyRateItem.CurrencyOut.CurrencyCode == ERP_Budget.Global.Consts.strCurrencyBudget)
                //    {
                //        strRet += ( "\n1 " + objCurrencyRateItem.CurrencyOut.CurrencyCode + " = " +
                //            System.String.Format("{0:### ###.000}", ( 1/objCurrencyRateItem.Value )) + " " + objCurrencyRateItem.CurrencyIn.CurrencyCode );
                //    }
                //}
                foreach (ERP_Budget.Common.CCurrencyRateItem objCurrencyRateItem in this.m_objCurrencyRateListForDivision)
                {
                        strRet += ("\n1 " + objCurrencyRateItem.CurrencyIn.CurrencyCode + " = " +
                            System.String.Format("{0:### ###.000}", objCurrencyRateItem.Value) + " " + objCurrencyRateItem.CurrencyOut.CurrencyCode);
                }

            
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка создания списка курсов валют.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return strRet;
        }
        #endregion

        #region Дефицит средств
        /// <summary>
        /// Проверка дефицита средств по статье
        /// </summary>
        private void CheckBalans()
        {
            try
            {
                // подсчет баланса имеет смысл, если есть возможность изменять сумму или статью бюджета
                if (this.m_bNeedCheckBalance == false) { return; }
                if (tlaypnlDemand_2.ColumnStyles.Count == 0) { return; }
                if ((cboxDebitArticle.Text == "") || (cboxDebitArticle.Text == strLoadText)) { return; }

                // 2009.07.07
                // остаток средств в валюте бюджета
                System.Double RestMoney = 0;
                // сумма заявки в валюте бюджета
                System.Double DocMoney = 0;
                // дефицит средств по статье в валюте бюджета
                System.Double DeficitMoney = 0;

                // сумма заявки в валюте бюджета
                if ((txtDocMoney.Text != "") && (txtDocMoney.Value > 0))
                {
                    DocMoney = System.Convert.ToDouble(txtDocMoney.GetValue());
                }

                // подсчитаем остаток по выбранным статьям
                if (treelistBudgetItem.Nodes.Count > 0)
                {
                    // пробежимся по списку и просуммируем остаток выбранных подстатей
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        // 2009.07.07
                        // включена проверка "if ((System.Boolean)objNode.GetValue(colCheck))"
                        if ((System.Boolean)objNode.GetValue(colCheck))
                        {
                            if( System.Convert.ToDouble(objNode.GetValue(colRestMoney) ) < System.Convert.ToDouble(objNode.GetValue(colMoneyBudget) ) )
                            {
                                DeficitMoney += ( System.Convert.ToDouble(objNode.GetValue(colRestMoney)) - System.Convert.ToDouble(objNode.GetValue(colMoneyBudget)) );
                            }
                            RestMoney += System.Convert.ToDouble(objNode.GetValue(colRestMoney));
                        }
                    }
                }
                else
                {
                    // обратимся к остатку статьи бюджета
                    if (m_objBudgetDoc.BudgetItem != null)
                    {
                        RestMoney = m_objBudgetDoc.BudgetItem.RestMoney;
                        // дефицит средств по статье
                        DeficitMoney = (RestMoney - DocMoney);
                    }
                }

                m_objBudgetDoc.Deficit = (DeficitMoney >= 0) ? 0 : (-DeficitMoney);
                txtDeficitMoney.Value = System.Convert.ToDecimal(m_objBudgetDoc.Deficit);
                txtDeficitMoney.Text = txtDeficitMoney.Value.ToString();

                // если это внебюджетные расходы, то прячем баланс по статье
                if (m_objBudgetDoc.BudgetItem.OffExpenditures == true)
                {
                    txtRestMoneyDebitArticle.Text = "";
                }
                else
                {
                    txtRestMoneyDebitArticle.Text = System.String.Format("{0:N}", DeficitMoney) + " " + ERP_Budget.Global.Consts.strCurrencyBudget;
                }

                // устанавливаем цвет
                txtRestMoneyDebitArticle.Properties.Appearance.BackColor = (DeficitMoney < 0) ? System.Drawing.Color.Tomato : System.Drawing.Color.LightGreen;

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка проверки остатка средств по статье : \"" + cboxDebitArticle.Text + "\"\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Элементы управления, влияющие на выбор маршрута
        /// <summary>
        /// Проверяет связь элементов управления с переменными, влияющими на выбор маршрута
        /// </summary>
        private void BindRouteVariablesWithControls()
        {
            // в классе присутствуют элементы управления, значения в которых влияют на выбор маршрута
            // необходимо проверить, которые из них связаны с переменными из списка m_objRouteVariableList
            // если для элемента управления такая связь есть, то нам важно знать, 
            // как и когда в нем изменится значение, что бы выбрать правильный маршрут
            try
            {
                //// сумма документа
                //InitControlForRouteVariable(txtDocMoney);
                //// служба
                //InitControlForRouteVariable(cboxBudgetDep);
                //// статья расходов
                //InitControlForRouteVariable(cboxDebitArticle);
                //// форма оплаты
                //InitControlForRouteVariable(cboxPaymentType);

                InitControlForRouteVariable( new List<Control>{txtDocMoney, cboxBudgetDep, cboxDebitArticle, cboxPaymentType} );

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Во время поиска элементов управления \nдля переменных, влияющих на выбор маршрута\nпроизошла ошибка.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Настравивает элемент управления
        /// </summary>
        /// <param name="objControl">элемент управления</param>
        private void InitControlForRouteVariable(Control objControl)
        {
            try
            {
                if ((m_objRouteVariableList == null) || (m_objRouteVariableList.Count == 0)) { return; }

                // если в списке есть переменная, связанная с классом элемента управления objControl,
                // то этот элемент управления будет влиять на выбор маршрута
                foreach (ERP_Budget.Common.CRouteVariable objRouteVariable in m_objRouteVariableList)
                {
                    if (objControl.GetType().Name.IndexOf(objRouteVariable.EditClassName) == 0)
                    {
                        if (objControl == txtDocMoney)
                        {
                            objControl.Validated += new EventHandler(this.txtDocMoney_Validated);
                        }
                        else
                        {
                            objControl.TextChanged += new EventHandler(this.RouteVariable_TextChanged);
                        }

                        break;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitControlForRouteVariable.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void InitControlForRouteVariable( List<Control> objControlList)
        {
            try
            {
                if ((m_objRouteVariableList == null) || (m_objRouteVariableList.Count == 0)) { return; }
                if ((objControlList == null) || (objControlList.Count == 0)) { return; }

                ERP_Budget.Common.CRouteVariable objRouteVariable = null;
                foreach( Control objControl in objControlList )
                {
                    objRouteVariable = null;
                    objRouteVariable = m_objRouteVariableList.SingleOrDefault<ERP_Budget.Common.CRouteVariable>(x => x.EditClassName.IndexOf(objControl.GetType().Name) == 0);
                    if (objRouteVariable != null)
                    {
                        // если в списке есть переменная, связанная с классом элемента управления objControl,
                        // то этот элемент управления будет влиять на выбор маршрута
                        if (objControl == txtDocMoney)
                        {
                            objControl.Validated += new EventHandler(this.txtDocMoney_Validated);
                        }
                        else
                        {
                            objControl.TextChanged += new EventHandler(this.RouteVariable_TextChanged);
                        }
                    }

                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitControlForRouteVariable.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        
        private void txtDocMoney_Validated(object sender, EventArgs e)
        {
            try
            {
                txtDocMoneyBudgetCurrency.Text = (txtDocMoney.Value > 0) ? (System.String.Format("{0:N}", txtDocMoney.GetValue()) + " " + txtDocMoney.CurrencyCodeBudget) : "";
                // сумма
                if ((m_objBudgetDoc.Currency != null) && (m_objCurrencyRateList != null) &&
                    (m_objBudgetDoc.BudgetItem != null))
                {
                    if (txtDocMoney.Value == 0)
                    {
                        m_objBudgetDoc.Money = 0;
                        m_objBudgetDoc.MoneyAgree = 0;
                    }
                    else
                    {
                        m_objBudgetDoc.Money = System.Convert.ToDouble(txtDocMoney.Value);
                        m_objBudgetDoc.MoneyAgree = System.Convert.ToDouble(txtDocMoney.GetValue());
                    }
                    if (treelistBudgetItem.Nodes.Count == 0)
                    {
                        // у статьи нет подстатей
                        if ((m_objBudgetDoc.BudgetItem != null) && ( m_objBudgetDoc.BudgetItemList != null ) &&  (m_objBudgetDoc.BudgetItemList.Count > 0))
                        {
                            m_objBudgetDoc.BudgetItemList[0].MoneyInBudgetCurrency = m_objBudgetDoc.MoneyAgree;
                            m_objBudgetDoc.BudgetItemList[0].MoneyInBudgetDocCurrency = m_objBudgetDoc.Money;
                        }
                    }
                    // остаток средств по статье
                    CheckBalans();
                }

                foreach (ERP_Budget.Common.CRouteVariable objRouteVariable in m_objRouteVariableList)
                {
                    if (txtDocMoney.GetType().Name.IndexOf(objRouteVariable.EditClassName) == 0)
                    {
                        objRouteVariable.m_strValue = ((ERP_Budget.Common.IRouteVariableEdit)txtDocMoney).GetValue();
                        // даем знать заинтересованным классам, что изменилось что-то,
                        // влияющее на выбор маршрута
                        SimulateChangeRouteVariable(objRouteVariable);
                        break;
                    }

                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции txtDocMoney_Validated.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Обработчик изменения текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteVariable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Control objControl = (Control)sender;
                // найдем переменную, связанную с элементом управления
                // и пропишем ее значение
                foreach (ERP_Budget.Common.CRouteVariable objRouteVariable in m_objRouteVariableList)
                {
                    if (objControl.GetType().Name.IndexOf(objRouteVariable.EditClassName) == 0)
                    {
                        objRouteVariable.m_strValue = ((ERP_Budget.Common.IRouteVariableEdit)objControl).GetValue();
                        // даем знать заинтересованным классам, что изменилось что-то,
                        // влияющее на выбор маршрута
                        SimulateChangeRouteVariable(objRouteVariable);
                        break;
                    }

                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции RouteVariable_TextChanged.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Элементы управления, влияющие на выбор типа документа
        /// <summary>
        /// Проверяет связь элементов управления с переменными, влияющими на выбор типа бюджетного документа
        /// </summary>
        private void BindDocTypeVariablesWithControls()
        {
            // в классе присутствуют элементы управления, значения в которых влияют на выбор типа бюджетного документа
            // необходимо проверить, которые из них связаны с переменными из списка m_objDocTypeVariableList
            // если для элемента управления такая связь есть, то нам важно знать, 
            // как и когда в нем изменится значение, что бы выбрать правильный тип документа
            try
            {
                // дефицит средств
                InitControlForDocTypeVariable(txtDeficitMoney);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Во время поиска элементов управления \nдля переменных, влияющих на выбор типа документа\nпроизошла ошибка.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Настравивает элемент управления
        /// </summary>
        /// <param name="objControl">элемент управления</param>
        private void InitControlForDocTypeVariable(Control objControl)
        {
            try
            {
                if ((m_objDocTypeVariableList == null) || (m_objDocTypeVariableList.Count == 0)) { return; }
                if ((m_objDocTypeVariableList == null) || (m_objDocTypeVariableList.Count == 0)) { return; }

                if (m_objDocTypeVariableList.SingleOrDefault<CBudgetDocTypeVariable>(x => x.EditClassName.IndexOf(objControl.GetType().Name) == 0) != null)
                {
                    objControl.TextChanged += new EventHandler(this.BudgetDocTypeVariable_TextChanged);
                }

                //// если в списке есть переменная, связанная с классом элемента управления objControl,
                //// то этот элемент управления будет влиять на выбор типа документа
                //foreach (ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariable in m_objDocTypeVariableList)
                //{
                //    if (objControl.GetType().Name.IndexOf(objDocTypeVariable.EditClassName) == 0)
                //    {
                //        objControl.TextChanged += new EventHandler(this.BudgetDocTypeVariable_TextChanged);

                //        break;
                //    }
                //}
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitControlForRouteVariable.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Обработчик изменения текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BudgetDocTypeVariable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Control objControl = (Control)sender;
                // найдем переменную, связанную с элементом управления
                // и пропишем ее значение
                foreach (ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariable in m_objDocTypeVariableList)
                {
                    if (objControl.GetType().Name.IndexOf(objDocTypeVariable.EditClassName) == 0)
                    {
                        objDocTypeVariable.m_strValue = ((ERP_Budget.Common.IBudgetDocTypeVariableEdit)objControl).GetValue();
                        // даем знать заинтересованным классам, что изменилось что-то,
                        // влияющее на выбор типа бюджетного документа
                        SimulateChangeDocTypeVariable(objDocTypeVariable);
                        break;
                    }

                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции BudgetDocTypeVariable_TextChanged.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Вложения

        private void AddFileToAttachList(System.String strFileFullName)
        {
            try
            {
                if (m_objBudgetDoc.AttachList == null) { m_objBudgetDoc.AttachList = new List<ERP_Budget.Common.CBudgetDocAttach>(); }

                // проверяем, существует ли указанный файл
                if (System.IO.File.Exists(strFileFullName) == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Указанный файл не найден.", "Ошибка",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }

                // создаем файловый поток
                System.IO.FileStream fs = new System.IO.FileStream(strFileFullName, System.IO.FileMode.Open);
                // FileInfo закачиваемого файла
                System.IO.FileInfo fi = new System.IO.FileInfo(strFileFullName);
                System.String strShortName = fi.Name;
                System.String strExtension = fi.Extension;
                int lung = Convert.ToInt32(fi.Length);
                // Считываем содержимое файла в массив байт.
                byte[] arAttach = new byte[lung];
                fs.Read(arAttach, 0, lung);
                fs.Close();
                fs = null;
                // Создаем объект "вложение"
                ERP_Budget.Common.CBudgetDocAttach objBudgetDocAttach = new ERP_Budget.Common.CBudgetDocAttach();
                objBudgetDocAttach.Name = strShortName;
                objBudgetDocAttach.TypeName = strExtension;
                objBudgetDocAttach.Attachment = arAttach;
                objBudgetDocAttach.FullFilePath = strFileFullName;
                // добавляем вложение в список
                // если файл с таким именем есть, то удалим его
                foreach (ERP_Budget.Common.CBudgetDocAttach objAttach in this.m_objBudgetDoc.AttachList)
                {
                    if (objAttach.Name == strShortName)
                    {
                        this.m_objBudgetDoc.AttachList.Remove(objAttach);
                        lstAttachment.Items.Remove(objAttach);
                        break;
                    }
                }

                this.m_objBudgetDoc.AttachList.Add(objBudgetDocAttach);
                lstAttachment.Items.Add(objBudgetDocAttach);

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка добавления файла в список вложений.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                if ((ofd.FileName == "") || (System.IO.File.Exists(ofd.FileName) == false))
                {
                    //
                    // Если с запрошенным файлом не всё в порядке
                    //
                    return;
                }
                AddFileToAttachList(ofd.FileName);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка добавления файла в список вложений.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;

        }
        /// <summary>
        /// Загружает список вложений к заявке
        /// </summary>
        private void LoadAttachList()
        {
            try
            {
                lstAttachment.Items.Clear();
                btnAttach.Visible = false;
                if ((m_objBudgetDoc.AttachList != null) && (m_objBudgetDoc.AttachList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CBudgetDocAttach objBudgetDocAttach in m_objBudgetDoc.AttachList)
                    {
                        lstAttachment.Items.Add(objBudgetDocAttach);
                    }
                    this.tlaypnlDemand_3.Controls.Remove(this.btnAttach);
                    System.Windows.Forms.Label lblAttach = new System.Windows.Forms.Label();
                    lblAttach.Name = "lblAttach";
                    lblAttach.Text = "Вложения: ";
                    lblAttach.Anchor = AnchorStyles.Left;
                    this.tlaypnlDemand_3.Controls.Add(lblAttach, 0, 5);

                }
                else
                {
                    tlaypnlDemand_3.RowStyles[5].Height = 0;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка добавления файла в список вложений.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        /// <summary>
        /// Запускает файл с вложением
        /// </summary>
        /// <param name="objBudgetDocAttach">объект "Вложение"</param>
        private void OpenAttach(ERP_Budget.Common.CBudgetDocAttach objBudgetDocAttach)
        {
            try
            {
                if (objBudgetDocAttach.Init(m_objProfile, objBudgetDocAttach.uuidID) == true)
                {
                    // Получить путь к системной папке.
                    System.String sysFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    System.String tmpFolder = Environment.GetEnvironmentVariable("TMP");
                    System.String strFileFullName = tmpFolder + @"\" + objBudgetDocAttach.Name;
                    // Удаляем файл с таким именем
                    if (System.IO.File.Exists(strFileFullName) == true)
                    {
                        System.IO.File.Delete(strFileFullName);
                    }
                    if (System.IO.File.Exists(strFileFullName) == true)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Файл с указанным именем уже существует и его не удалось обновить.", "Внимание",
                           System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        return;
                    }

                    // создаем файловый поток
                    System.IO.FileStream fs = new System.IO.FileStream(strFileFullName, System.IO.FileMode.Create);
                    System.IO.FileInfo fi = new System.IO.FileInfo(strFileFullName);
                    int lung = Convert.ToInt32(objBudgetDocAttach.Attachment.Length);
                    // Считываем содержимое вложения в файл
                    fs.Write(objBudgetDocAttach.Attachment, 0, lung);
                    fs.Close();
                    fs = null;

                    //Создать новую структуру ProcessStartInfo.
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    //Вставка состовляющих имени файла.
                    pInfo.FileName = strFileFullName;
                    // Значение структуры UseShellExecute по умолчанию true. Здесь вставлено для иллюстрации.
                    pInfo.UseShellExecute = true;
                    Process p = Process.Start(pInfo);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Не удалось загрузить вложение.", "Внимание",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка открытия вложения.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        /// <summary>
        /// Запускает выделенный файл с вложением
        /// </summary>
        private void OpenSelectedAttach()
        {
            try
            {
                if (lstAttachment.Items.Count == 0) { return; }
                if (lstAttachment.SelectedItem == null) { return; }

                ERP_Budget.Common.CBudgetDocAttach objBudgetDocAttach = (ERP_Budget.Common.CBudgetDocAttach)lstAttachment.SelectedItem;
                if (objBudgetDocAttach.FullFilePath == "") { return; }
                if (System.IO.File.Exists(objBudgetDocAttach.FullFilePath) == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Не удалось найти файл с указанным именем.\nИмя файла: " + objBudgetDocAttach.FullFilePath, "Внимание",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }

                //Создать новую структуру ProcessStartInfo.
                ProcessStartInfo pInfo = new ProcessStartInfo();
                //Вставка состовляющих имени файла.
                pInfo.FileName = objBudgetDocAttach.FullFilePath;
                // Значение структуры UseShellExecute по умолчанию true. Здесь вставлено для иллюстрации.
                pInfo.UseShellExecute = true;
                Process p = Process.Start(pInfo);

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка открытия вложения.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        private void lstAttachment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lstAttachment.Items.Count == 0) { return; }
                if (lstAttachment.SelectedItem == null) { return; }

                if (this.m_ViewDocVariant == enumViewDocVariant.NewDocument)
                {
                    OpenSelectedAttach();
                }
                else
                {
                    OpenAttach((ERP_Budget.Common.CBudgetDocAttach)lstAttachment.SelectedItem);
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка открытия вложения.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        private void lstAttachment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (lstAttachment.Enabled == false) { return; }
                if (lstAttachment.Items.Count == 0) { return; }
                if (lstAttachment.SelectedItem == null) { return; }
                if (this.m_ViewDocVariant != enumViewDocVariant.NewDocument) { return; }

                if (e.KeyCode == Keys.Delete)
                {
                    this.m_objBudgetDoc.AttachList.Remove((ERP_Budget.Common.CBudgetDocAttach)lstAttachment.SelectedItem);
                    lstAttachment.Items.Remove(lstAttachment.SelectedItem);
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка открытия вложения.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        #endregion

        #region Оповещение
        /// <summary>
        /// Проверяет сочетание "Компания - Вид платежа"
        /// </summary>
        private void CheckConstrtCompanyPayType()
        {
            try
            {
                // для наличного платежа (2) компания должна быть "---"
                if (m_DocStateVariant != enumDocStateVariant.NewDocument)
                {
                    return;
                }
                System.String strCompany = (cboxCompany.SelectedItem == null) ? "" : cboxCompany.Text;
                System.String strPayType = (cboxPaymentType.SelectedItem == null) ? "" : cboxPaymentType.Text;
                if ((strCompany == "") || (strPayType == ""))
                {
                    return;
                }
                System.Boolean bNeedWarning = (((strPayType == "2") && (strCompany != "---")) || ((strPayType != "2") && (strCompany == "---")));

                if (bNeedWarning == true)
                {
                    lblOpenInfoTop.Visible = false;
                    lblOpenInfoBotton.Location = new Point(lblOpenInfoBotton.Location.X, 10);
                    lblOpenInfoBotton.ForeColor = System.Drawing.Color.DimGray;
                    lblOpenInfoBotton.Text = "Для заданного типа платежа (2) нужно указать Компанию \"---\"";
                    tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = iOpenPnlHight;
                }
                else
                {
                    if (tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height > 0)
                    {
                        tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = 0;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка проверки компании и вида платежа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        #endregion

        private void treelistBudgetItem_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            try
            {
                if( m_ViewDocVariant != enumViewDocVariant.NewDocument )  
                {
                    e.Handled = true;
                    return; 
                }
                
                System.Double RestMoney = 0;
                System.Double DocMoney = 0;
                if (treelistBudgetItem.Nodes.Count == 0) { return; }
                if (e.Node == null) { return; }
                int Y = e.SelectRect.Top + (e.SelectRect.Height - imageCollection.Images[0].Height) / 2;
                if (e.Node.Tag != null)
                {
                    if (System.Convert.ToBoolean(e.Node.GetValue(colCheck)) == true)
                    {
                        DocMoney = System.Convert.ToDouble(e.Node.GetValue(colMoneyBudget));
                        RestMoney = System.Convert.ToDouble(e.Node.GetValue(colRestMoney));
                        if (DocMoney > RestMoney)
                        {
                            // дефицит средств
                            try
                            {
                                e.Graphics.DrawImage(imageCollection.Images[1], new Point(e.SelectRect.X, Y));
                                e.Handled = true;
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                e.Graphics.DrawImage(imageCollection.Images[0], new Point(e.SelectRect.X, Y));
                                e.Handled = true;
                            }
                            catch { }
                        }

                        if (System.Convert.ToString(e.Node.GetValue(colAccountPlan)) == "")
                        {
                            try
                            {
                                e.Graphics.DrawImage(imageCollection.Images[1], new Point(e.SelectRect.X, Y));
                                e.Handled = true;
                            }
                            catch { }
                        }

                    }
                    else
                    {
                        try
                        {
                            e.Graphics.DrawImage(imageCollection.Images[2], new Point(e.SelectRect.X, Y));
                            e.Handled = true;
                        }
                        catch { }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( "Ошибка отрисовки картинок в узлах.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                mitemDetail.Enabled = ( ( treelistBudgetItem.FocusedNode != null ) && 
                    ( ( m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRInspector) == true ) ||
                      (m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRManager) == true)));
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка contextMenuStrip_Opening.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void mitemDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                frmBudgetItemDetail objfrmBudgetItemDetail = new frmBudgetItemDetail(m_objProfile, (ERP_Budget.Common.CBudgetItem)treelistBudgetItem.FocusedNode.Tag);
                objfrmBudgetItemDetail.ShowDialog();
                objfrmBudgetItemDetail.Dispose();
            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "Ошибка детализации статьи бюджета.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void treelistBudgetItem_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if( ( e.KeyChar == (char)Keys.Enter )  && (m_ViewDocVariant == enumViewDocVariant.NewDocument) )
                {
                    treelistBudgetItem.FocusedNode.SetValue(colMoney, treelistBudgetItem.FocusedNode.GetDisplayText(colMoney));
                }
            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "treelistBudgetItem_EditorKeyPress.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        public System.Boolean ConfirmBudgetDocMoney()
        {
            System.Boolean bRes = false;
            try
            {
                if (m_ViewDocVariant == enumViewDocVariant.NewDocument)
                {
                    if (cboxBudgetDep.Focus() == true)
                    {
                        cboxBudgetDep.SelectAll();
                        bRes = true;
                    }
                }
                else
                {
                    bRes = true;
                }
            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "ConfirmBudgetDocMoney.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRes;
        }

        private void txtDocMoney_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        }

        private void txtDocMoney_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void treelistBudgetItem_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            try
            {
                if ((e.Node == treelistBudgetItem.FocusedNode && e.Column != treelistBudgetItem.FocusedColumn) || e.Node == null || e.Column == null) return;
                if (System.Convert.ToString(e.Node.GetValue(colAccountPlan)) == "")
                {
                    
                    e.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Strikeout);
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "treelistBudgetItem_CustomDrawNodeCell.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void treelistBudgetItem_Leave(object sender, EventArgs e)
        {
        }


    }


}
