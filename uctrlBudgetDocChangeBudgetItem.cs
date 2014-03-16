using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ErpBudgetBudgetDoc
{
    public partial class uctrlBudgetDocChangeBudgetItem : UserControl, IBudgetDoc
    {
        #region Переменные, свойства
        /// <summary>
        /// Ссылка на объект "Профайл"
        /// </summary>
        private UniXP.Common.CProfile m_objProfile;
        /// <summary>
        /// Ссылка на объект "Бюджет"
        /// </summary>
        private ERP_Budget.Common.CBudget m_objBudget;
        /// <summary>
        /// Ссылка на объект "Бюджетный документ"
        /// </summary>
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;
        /// <summary>
        /// Ссылка на список переменных, влияющих на выбор маршрута
        /// </summary>
        private List<ERP_Budget.Common.CRouteVariable> m_objRouteVariableList;
        /// <summary>
        /// список курсов валют
        /// </summary>
        private System.Collections.Generic.List<ERP_Budget.Common.CCurrencyRateItem> m_objCurrencyRateList;
        /// <summary>
        /// Признак того, что сумма документа меняется из списка дочерних статей
        /// </summary>
        private System.Boolean m_bWriteFromChildList;
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
        private const System.String strLoadText = "загрузка...";
        private const System.Int32 iOpenPnlHight = 45;

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

        #endregion

        #region Конструктор
        public uctrlBudgetDocChangeBudgetItem(UniXP.Common.CProfile objProfile,
            ERP_Budget.Common.CBudgetDoc objBudgetDoc,
            List<ERP_Budget.Common.CRouteVariable> objRouteVariableList,
            enumDocStateVariant DocStateVariant, System.String strDR, System.String strMainDynamicRight,
            System.Boolean bIsActionUser)
        {
            InitializeComponent();

            m_objProfile = objProfile;
            m_objBudgetDoc = objBudgetDoc;
            m_objCurrencyRateList = null;
            m_bWriteFromChildList = false;
            m_ViewDocVariant = enumViewDocVariant.Unkown;
            m_DocStateVariant = DocStateVariant;
            m_strDR = strDR;
            m_strMainDynamicRight = strMainDynamicRight;
            m_bIsActionUser = bIsActionUser;
            m_IOpenDoc = false;
            m_objRouteVariableList = objRouteVariableList;
            m_objBudget = null;
            m_objBudgetDoc.IsResetBudgetItem = true;

            InitVariables();
        }
        private void InitVariables()
        {
            try
            {
                //сперва нужно определить вариант отображения заявки
                SetViewDocVariant();

                // если мы имеем дело с ранее сохраненным документом,
                // то для списка статей нужно загрузить расшифровки по месяцам
                if ((m_objBudgetDoc != null) && (m_objBudgetDoc.BudgetItem != null) &&
                    (m_objBudgetDoc.BudgetItemList != null) && (m_objBudgetDoc.BudgetItemList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in m_objBudgetDoc.BudgetItemList)
                    {
                        objBudgetItem.LoadBudgetDocItemDecodeList(m_objProfile, m_objBudgetDoc.uuidID);
                    }
                    // ... очень смахивает на жульство, но каждая статья бюджета в нашем списке
                    // содержит УИ бюджета... попробуем использовать этот момент для инициализации объекта "Бюджет"
                    if (m_objBudgetDoc.BudgetItemList[0].BudgetGUID != System.Guid.Empty)
                    {
                        m_objBudget = new ERP_Budget.Common.CBudget();
                        m_objBudget.Init(m_objProfile, m_objBudgetDoc.BudgetItemList[0].BudgetGUID);
                    }
                }
                btnAddChildBudgetItem.Enabled = false;
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

        #region GetOpenDocFlag
        public System.Boolean GetOpenDocFlag()
        {
            return m_IOpenDoc;
        }
        #endregion

        #region SetFocus
        public void SetFocus()
        {
            cboxBudget.Focus();
        }
        #endregion

        #region bOpenBudgetDoc
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

                // для компании и формы расчетов нет элементов управления
                // поэтому установим эти значения принудительно

                // компания
                List<ERP_Budget.Common.CCompany> objCompanyList = ERP_Budget.Common.CCompany.GetCompanyList(m_objProfile);
                if ((objCompanyList == null) || (objCompanyList.Count == 0))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Не удалось установить компанию!\nСоздание документа отменено.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return bRet;
                }
                cboxCompany.Properties.Items.Clear();
                foreach (ERP_Budget.Common.CCompany objCompany in objCompanyList)
                {
                    cboxCompany.Properties.Items.Add(objCompany);
                }
                //objCompanyList = null;

                // форма оплаты
                List<ERP_Budget.Common.CPaymentType> objPaymentTypeList = ERP_Budget.Common.CPaymentType.GetPaymentTypesList(m_objProfile);
                if ((objPaymentTypeList == null) || (objPaymentTypeList.Count == 0))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Не удалось установить форму оплаты!\nСоздание документа отменено.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return bRet;
                }
                cboxPaymentType.Properties.Items.Clear();
                foreach (ERP_Budget.Common.CPaymentType objPaymentType in objPaymentTypeList)
                {
                    cboxPaymentType.Properties.Items.Add(objPaymentType);
                }
                //objPaymentTypeList = null;

                // цель
                m_objBudgetDoc.Objective = "-";
                // документальное обоснование
                m_objBudgetDoc.DocBasis = "-";
                // получатель
                m_objBudgetDoc.Recipient = "-";

                // заполним выпадающие списки
                RefreshAllComboBox();

                // список курсов валют
                LoadCurrencyRateList();

                BindRouteVariablesWithControls();

                if (bResetBudgetDocControls(true) == true)
                {
                    // прячем/отображаем список подстатей
                    SetTreeListBudgetItemSize();
                    bRet = true;
                }
                cboxCompany.SelectedItem = cboxCompany.Properties.Items[0];
                cboxPaymentType.SelectedItem = cboxPaymentType.Properties.Items[0];
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
                // Бюджеты
                cboxBudget.Properties.Items.Clear();
                if (m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRManager) == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "У Вас недостаточно прав для создания ноты на изменение бюджета.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }
                List<ERP_Budget.Common.CBudget> objBudgetList = ERP_Budget.Common.CBudget.GetBudgetList(m_objProfile);
                if ((objBudgetList == null) || (objBudgetList.Count == 0))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Список бюджетов пуст.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }
                foreach (ERP_Budget.Common.CBudget objBudget in objBudgetList)
                {
                    // нас интересуют бюджеты текущего года
                    if (objBudget.Date.Year != System.DateTime.Today.Year) { continue; }

                    // где распорядитель - текущий пользователь
                    if (objBudget.BudgetDep.Manager.ulUniXPID != m_objProfile.m_nSQLUserID) { continue; }

                    //// бюджет должен быть утвержден
                    //if (objBudget.IsAccept == false) { continue; }

                    cboxBudget.Properties.Items.Add(objBudget);
                }
                objBudgetList = null;
                if (cboxBudget.Properties.Items.Count == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Список бюджетов пуст.\nСоздание ноты невозможно.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }
                // Валюты
                cboxCurrency.Properties.Items.Clear();
                List<ERP_Budget.Common.CCurrency> objCurrencyList = ERP_Budget.Common.CCurrency.GetCurrencyList(m_objProfile);
                foreach (ERP_Budget.Common.CCurrency objCurrency in objCurrencyList)
                {
                    cboxCurrency.Properties.Items.Add(objCurrency);
                }
                // Статьи расходов
                cboxDebitArticle.Properties.Items.Clear();
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
                m_objBudgetDoc.IsResetBudgetItem = true;
                // Валюты
                cboxCurrency.Properties.Items.Clear();
                List<ERP_Budget.Common.CCurrency> objCurrencyList = ERP_Budget.Common.CCurrency.GetCurrencyList(m_objProfile);
                foreach (ERP_Budget.Common.CCurrency objCurrency in objCurrencyList)
                {
                    cboxCurrency.Properties.Items.Add(objCurrency);
                }
                // список курсов валют
                LoadCurrencyRateList();
                // присваиваем элементам управления значения из свойств заявки
                bRet = bResetBudgetDocControls(true);
                if (bRet)
                {
                    // теперь нужно заблокировать некоторые элементы управления
                    cboxBudget.Properties.ReadOnly = true;
                    cboxDebitArticle.Properties.ReadOnly = true;
                }
                btnAddChildBudgetItem.Enabled = false;
                txtDocMoney.CurrencyCode = m_objBudgetDoc.Currency.CurrencyCode;
                txtDocMoney.CurrencyCodeBudget = ERP_Budget.Global.Consts.strCurrencyBudget;
                txtDocMoney.CurrencyRate = (txtDocMoney.CurrencyCode == txtDocMoney.CurrencyCodeBudget) ? 1 : GetCurrencyRate(txtDocMoney.CurrencyCode);
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
                // прячем столбец "Остаток"
                colRestMoney.VisibleIndex = -1;

                // присваиваем элементам управления значения из свойств заявки
                bRet = bResetBudgetDocControls(true);
                if (bRet)
                {
                    // блокируем элементы управления
                    cboxBudget.Enabled = false;
                    cboxCurrency.Enabled = false;
                    txtDocMoney.Enabled = false;
                    cboxDebitArticle.Enabled = false;
                    txtDocDescription.Enabled = false;
                    foreach (DevExpress.XtraTreeList.Columns.TreeListColumn objColumn in treelistBudgetItem.Columns)
                    {
                        objColumn.OptionsColumn.ReadOnly = true;
                        objColumn.OptionsColumn.AllowEdit = false;
                    }
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

        #region Копия документа
        public System.Boolean CopyBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            System.Boolean bRet = false;
            try
            {
                if ((m_objBudgetDoc == null) || (objBudgetDoc == null)) { return bRet; }
                tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = 0;

                // создаем новый документ
                bRet = bOpenBudgetDocNew();

                if (bRet == true)
                {
                    // удалось создать новый документ, теперь пропишем его свойства из исходного документа
                    // скопируем свойства исходной заявки в текущую
                    m_objBudgetDoc.Copy(objBudgetDoc);

                    // Служба
                    if (objBudgetDoc.BudgetDep != null)
                    {
                        foreach (ERP_Budget.Common.CBudgetDep objBudgetDep in cboxBudgetDep.Properties.Items)
                        {
                            if (objBudgetDoc.BudgetDep.uuidID == objBudgetDep.uuidID)
                            {
                                cboxBudgetDep.SelectedItem = objBudgetDep;
                                break;
                            }
                        }
                    }
                    // Компания
                    if (objBudgetDoc.Company != null)
                    {
                        foreach (ERP_Budget.Common.CCompany objCompany in cboxCompany.Properties.Items)
                        {
                            if (objBudgetDoc.Company.uuidID == objCompany.uuidID)
                            {
                                cboxCompany.SelectedItem = objCompany;
                                break;
                            }
                        }
                    }
                    // Форма расчетов
                    if (objBudgetDoc.PaymentType != null)
                    {
                        foreach (ERP_Budget.Common.CPaymentType objPaymentType in cboxPaymentType.Properties.Items)
                        {
                            if (objBudgetDoc.PaymentType.uuidID == objPaymentType.uuidID)
                            {
                                cboxPaymentType.SelectedItem = objPaymentType;
                                break;
                            }
                        }
                    }
                    // Валюта
                    if (objBudgetDoc.Currency != null)
                    {
                        foreach (ERP_Budget.Common.CCurrency objCurrency in cboxCurrency.Properties.Items)
                        {
                            if (objBudgetDoc.Currency.uuidID == objCurrency.uuidID)
                            {
                                cboxCurrency.SelectedItem = objCurrency;
                                break;
                            }
                        }
                    }
                    // Бюджет
                    // загрузим список статей для исходного документа
                    objBudgetDoc.LoadBudgetItemList(m_objProfile);
                    if (objBudgetDoc.BudgetItemList[0].BudgetGUID != System.Guid.Empty)
                    {
                        m_objBudget = new ERP_Budget.Common.CBudget();
                        m_objBudget.Init(m_objProfile, objBudgetDoc.BudgetItemList[0].BudgetGUID);
                    }

                    if (m_objBudget != null)
                    {
                        foreach (ERP_Budget.Common.CBudget objBudget in cboxBudget.Properties.Items)
                        {
                            if (m_objBudget.uuidID == objBudget.uuidID)
                            {
                                cboxBudget.SelectedItem = objBudget;
                                break;
                            }
                        }
                    }
                    // Статья расходов
                    if (objBudgetDoc.BudgetItem != null)
                    {
                        foreach (Object objItem in cboxDebitArticle.Properties.Items)
                        {

                            if (objItem.GetType() == typeof(System.String)) { continue; }
                            ERP_Budget.Common.CPopupBudgetItem objPopupBudgetItem = (ERP_Budget.Common.CPopupBudgetItem)objItem;
                            if (objBudgetDoc.BudgetItem.BudgetItemFullName == objPopupBudgetItem.ParentBudgetItem.BudgetItemFullName)
                            {
                                cboxDebitArticle.SelectedItem = (ERP_Budget.Common.CPopupBudgetItem)objItem;
                                // остаток средств
                                m_objBudgetDoc.BudgetItem.RestMoney =
                                        ERP_Budget.Common.CBudgetItem.GetParentBudgetItemBalans(m_objBudgetDoc.BudgetItem.uuidID,
                                        m_objProfile);
                                txtRestMoneyDebitArticle.Visible = (m_ViewDocVariant != enumViewDocVariant.Arj);
                                txtRestMoneyDebitArticle.Text = System.String.Format("{0:N}", m_objBudgetDoc.BudgetItem.RestMoney) + " " +
                                    ERP_Budget.Global.Consts.strCurrencyBudget;
                                // обновляет список подстатей
                                RefreshChildDebitArticleList(objPopupBudgetItem);

                                foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in objBudgetDoc.BudgetItemList)
                                {
                                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                                    {
                                        if ((System.String)objNode.GetValue(colBudgetItemName) == objBudgetItem.BudgetItemFullName)
                                        {
                                            objNode.SetValue(colCheck, true);

                                            System.Double CurrencyRate = System.Convert.ToDouble(GetCurrencyRate(txtDocMoney.CurrencyCode));

                                            ERP_Budget.Common.CBudgetItem objItemTag = (ERP_Budget.Common.CBudgetItem)objNode.Tag;
                                            objItemTag.JanuaryDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.JanuaryDecode.MoneyPlan = objBudgetItem.JanuaryDecode.MoneyPlan;
                                            objItemTag.JanuaryDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.JanuaryDecode.MoneyPlan;

                                            objItemTag.FebruaryDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.FebruaryDecode.MoneyPlan = objBudgetItem.FebruaryDecode.MoneyPlan;
                                            objItemTag.FebruaryDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.FebruaryDecode.MoneyPlan;

                                            objItemTag.MarchDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.MarchDecode.MoneyPlan = objBudgetItem.MarchDecode.MoneyPlan;
                                            objItemTag.MarchDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.MarchDecode.MoneyPlan;

                                            objItemTag.AprilDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.AprilDecode.MoneyPlan = objBudgetItem.AprilDecode.MoneyPlan;
                                            objItemTag.AprilDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.AprilDecode.MoneyPlan;

                                            objItemTag.MayDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.MayDecode.MoneyPlan = objBudgetItem.MayDecode.MoneyPlan;
                                            objItemTag.MayDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.MayDecode.MoneyPlan;

                                            objItemTag.JuneDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.JuneDecode.MoneyPlan = objBudgetItem.JuneDecode.MoneyPlan;
                                            objItemTag.JuneDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.JuneDecode.MoneyPlan;

                                            objItemTag.JulyDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.JulyDecode.MoneyPlan = objBudgetItem.JulyDecode.MoneyPlan;
                                            objItemTag.JulyDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.JulyDecode.MoneyPlan;

                                            objItemTag.AugustDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.AugustDecode.MoneyPlan = objBudgetItem.AugustDecode.MoneyPlan;
                                            objItemTag.AugustDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.AugustDecode.MoneyPlan;

                                            objItemTag.SeptemberDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.SeptemberDecode.MoneyPlan = objBudgetItem.SeptemberDecode.MoneyPlan;
                                            objItemTag.SeptemberDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.SeptemberDecode.MoneyPlan;

                                            objItemTag.OctoberDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.OctoberDecode.MoneyPlan = objBudgetItem.OctoberDecode.MoneyPlan;
                                            objItemTag.OctoberDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.OctoberDecode.MoneyPlan;

                                            objItemTag.NovemberDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.NovemberDecode.MoneyPlan = objBudgetItem.NovemberDecode.MoneyPlan;
                                            objItemTag.NovemberDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.NovemberDecode.MoneyPlan;

                                            objItemTag.DecemberDecode.Currency = m_objBudgetDoc.Currency;
                                            objItemTag.DecemberDecode.MoneyPlan = objBudgetItem.DecemberDecode.MoneyPlan;
                                            objItemTag.DecemberDecode.MoneyPlanAccept = CurrencyRate * objBudgetItem.DecemberDecode.MoneyPlan;

                                            objNode.SetValue(colMoney1, objBudgetItem.JanuaryDecode.MoneyPlan);
                                            objNode.SetValue(colMoney2, objBudgetItem.FebruaryDecode.MoneyPlan);
                                            objNode.SetValue(colMoney3, objBudgetItem.MarchDecode.MoneyPlan);
                                            objNode.SetValue(colMoney4, objBudgetItem.AprilDecode.MoneyPlan);
                                            objNode.SetValue(colMoney5, objBudgetItem.MayDecode.MoneyPlan);
                                            objNode.SetValue(colMoney6, objBudgetItem.JuneDecode.MoneyPlan);
                                            objNode.SetValue(colMoney7, objBudgetItem.JulyDecode.MoneyPlan);
                                            objNode.SetValue(colMoney8, objBudgetItem.AugustDecode.MoneyPlan);
                                            objNode.SetValue(colMoney9, objBudgetItem.SeptemberDecode.MoneyPlan);
                                            objNode.SetValue(colMoney10, objBudgetItem.OctoberDecode.MoneyPlan);
                                            objNode.SetValue(colMoney11, objBudgetItem.NovemberDecode.MoneyPlan);
                                            objNode.SetValue(colMoney12, objBudgetItem.DecemberDecode.MoneyPlan);
                                            objNode.SetValue(colMoneySum, 0);
                                            //objNode.SetValue(colMoneySum, objBudgetItem.GetMoneyAgreeSum());

                                            RecalcNodeSum(objNode);
                                            SetBudgetItemList(colCheck, objNode);
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                        // пересчитаем сумму бюджетного документа
                        RecalcDocMoney();

                        txtDocMoney_Validated(txtDocMoney, new EventArgs());
                    }
                    // примечание
                    txtDocDescription.Text = objBudgetDoc.Description;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка копирования заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }

        #endregion

        #region ReorganizeDocSum
        /// <summary>
        /// Распределяет сумму документа по подстатьям
        /// </summary>
        public System.Boolean ReorganizeDocSum()
        {
            System.Boolean bRet = true;
            try
            {
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

        #region ConfirmBudgetDocMoney
        public System.Boolean ConfirmBudgetDocMoney()
        {
            return true;
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
                System.Collections.Generic.List<ERP_Budget.Common.CCurrencyRateItem> objCurrencyRateList =
                    ERP_Budget.Common.CCurrencyRateItem.GetCurrencyRateList(m_objProfile, System.DateTime.Today,
                    new System.Guid("ecca8152-4248-4054-896f-c5d373ce56b6"));
                if ((objCurrencyRateList != null) && (objCurrencyRateList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CCurrencyRateItem objCurrencyRateItem in objCurrencyRateList)
                    {
                        this.m_objCurrencyRateList.Add(objCurrencyRateItem);
                    }
                    objCurrencyRateList = null;
                }

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

        #endregion

        #region ResetBudgetDocControls
        /// <summary>
        /// Присваивает элементам управления значения свойств объекта "Заявка"
        /// </summary>
        /// <param name="bBlockEvents">Признак того, что сперва нужно отключить обработчики событий</param>
        /// <returns>true - удачное завершение; false - ошибка</returns>
        private System.Boolean bResetBudgetDocControls(System.Boolean bBlockEvents)
        {
            System.Boolean bRet = false;
            if (m_objBudgetDoc == null) { return bRet; }
            try
            {
                //txtDocMoney.Enabled = false;
                // сперва поотключаем обработчики событий
                if (bBlockEvents == true)
                {

                    cboxBudget.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                    cboxBudgetDep.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                    cboxCompany.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                    cboxPaymentType.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                    txtDocMoney.EditValueChanging -= new DevExpress.XtraEditors.Controls.ChangingEventHandler(txtDocMoney_EditValueChanging);
                    txtDocDescription.EditValueChanged -= new EventHandler(EditValueChanged);
                    cboxDebitArticle.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                    cboxCurrency.SelectedValueChanged -= new EventHandler(SelectedValueChanged);
                    treelistBudgetItem.CellValueChanged -= new DevExpress.XtraTreeList.CellValueChangedEventHandler(treelistBudgetItem_CellValueChanged);
                }

                // теперь присвоим заявке нужные значения
                // валюта
                if (m_objBudgetDoc.Currency != null)
                {
                    cboxCurrency.Properties.Items.Clear();
                    cboxCurrency.Properties.Items.Add(m_objBudgetDoc.Currency.CurrencyCode);
                    cboxCurrency.SelectedItem = cboxCurrency.Properties.Items[0];
                }
                // бюджет
                if (m_objBudget != null)
                {
                    cboxBudget.Properties.Items.Clear();
                    cboxBudget.Properties.Items.Add(m_objBudget);
                    cboxBudget.SelectedItem = cboxBudget.Properties.Items[0];
                }
                // сумма
                txtDocMoney.Value = System.Convert.ToDecimal(m_objBudgetDoc.Money);
                txtDocMoney.Properties.DisplayFormat.FormatString = "### ### ###.##";
                txtDocMoney.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                // сумма в валюте бюджета
                txtDocMoneyBudgetCurrency.Text = System.String.Format("{0:N}", m_objBudgetDoc.MoneyAgree) + " " + ERP_Budget.Global.Consts.strCurrencyBudget;
                // примечание
                txtDocDescription.Text = m_objBudgetDoc.Description;

                System.Boolean bShowRestMoney = !(m_DocStateVariant == enumDocStateVariant.ArjDocument); // && (m_objBudgetDoc.BudgetItem.OffExpenditures == false);
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
                    treelistBudgetItem.CellValueChanged -= new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treelistBudgetItem_CellValueChanged);
                    if ((m_objBudgetDoc.BudgetItemList != null) && (m_objBudgetDoc.BudgetItemList.Count > 0))
                    {
                        foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in m_objBudgetDoc.BudgetItemList)
                        {
                            //if (objBudgetItem.ParentID.CompareTo(System.Guid.Empty) == 0) { continue; }
                            DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                            treelistBudgetItem.AppendNode(new object[] { true, 
                                objBudgetItem.BudgetItemFullName, objBudgetItem.RestMoney, 
                                objBudgetItem.JanuaryDecode.MoneyPlan,
                                objBudgetItem.FebruaryDecode.MoneyPlan,
                                objBudgetItem.MarchDecode.MoneyPlan,
                                objBudgetItem.AprilDecode.MoneyPlan,
                                objBudgetItem.MayDecode.MoneyPlan,
                                objBudgetItem.JuneDecode.MoneyPlan,
                                objBudgetItem.JulyDecode.MoneyPlan,
                                objBudgetItem.AugustDecode.MoneyPlan,
                                objBudgetItem.SeptemberDecode.MoneyPlan,
                                objBudgetItem.OctoberDecode.MoneyPlan,
                                objBudgetItem.NovemberDecode.MoneyPlan,
                                objBudgetItem.DecemberDecode.MoneyPlan,
                                GetNodeSum( objBudgetItem ) }, null);
                            objNode.Tag = objBudgetItem;
                        }

                    }
                    if (treelistBudgetItem.Nodes.Count > 0)
                    {
                        this.m_bWriteFromChildList = true;
                    }
                    // остаток средств
                    m_objBudgetDoc.BudgetItem.RestMoney =
                            ERP_Budget.Common.CBudgetItem.GetParentBudgetItemBalans(m_objBudgetDoc.BudgetItem.uuidID,
                            this.m_objProfile);
                    txtRestMoneyDebitArticle.Visible = bShowRestMoney;
                    txtRestMoneyDebitArticle.Text = System.String.Format("{0:N}", m_objBudgetDoc.BudgetItem.RestMoney) + " " +
                        ERP_Budget.Global.Consts.strCurrencyBudget;

                }
                else
                {
                    txtRestMoneyDebitArticle.Visible = bShowRestMoney;
                    txtRestMoneyDebitArticle.Text = "";
                }

                // прячем/отображаем список подстатей
                SetTreeListBudgetItemSize();

                // Изменяет фон элементов управления
                ChangeBackGrnd();

                // теперь нужно включить обработчики событий у элементов управления
                switch (m_ViewDocVariant)
                {
                    case enumViewDocVariant.NewDocument:
                        txtDocMoney.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(txtDocMoney_EditValueChanging);
                        txtDocDescription.EditValueChanged += new EventHandler(EditValueChanged);
                        cboxBudget.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxBudgetDep.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxCompany.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxPaymentType.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        cboxDebitArticle.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        treelistBudgetItem.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(treelistBudgetItem_CellValueChanged);
                        repItemCalcEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(repItemCalcEdit_EditValueChanging);
                        cboxCurrency.SelectedValueChanged += new EventHandler(SelectedValueChanged);
                        break;
                    case enumViewDocVariant.BlockControl:
                        txtDocMoney.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(txtDocMoney_EditValueChanging);
                        txtDocDescription.EditValueChanged += new EventHandler(EditValueChanged);
                        treelistBudgetItem.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(treelistBudgetItem_CellValueChanged);
                        repItemCalcEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(repItemCalcEdit_EditValueChanging);
                        cboxCurrency.SelectedValueChanged += new EventHandler(SelectedValueChanged);
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

        System.Double GetNodeSum(ERP_Budget.Common.CBudgetItem objBudgetItem)
        {
            System.Double dRet = 0;
            if (objBudgetItem == null)
            {
                return dRet;
            }
            try
            {
                dRet = objBudgetItem.JanuaryDecode.MoneyPlan +
                        objBudgetItem.FebruaryDecode.MoneyPlan +
                        objBudgetItem.MarchDecode.MoneyPlan +
                        objBudgetItem.AprilDecode.MoneyPlan +
                        objBudgetItem.MayDecode.MoneyPlan +
                        objBudgetItem.JuneDecode.MoneyPlan +
                        objBudgetItem.JulyDecode.MoneyPlan +
                        objBudgetItem.AugustDecode.MoneyPlan +
                        objBudgetItem.SeptemberDecode.MoneyPlan +
                        objBudgetItem.OctoberDecode.MoneyPlan +
                        objBudgetItem.NovemberDecode.MoneyPlan +
                        objBudgetItem.DecemberDecode.MoneyPlan;

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка подсчета итоговой суммы.\n\nСтатья: " + objBudgetItem.BudgetItemFullName + ".\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return dRet;
        }

        #endregion

        #region Список статей и подстатей
        /// <summary>
        /// Обновляет выпадающий список статей бюджета для выбранной служба
        /// </summary>
        private void RefreshDebitArticleList()
        {
            try
            {
                // очищаем список статей
                treelistBudgetItem.Tag = null;
                cboxDebitArticle.Text = strLoadText;
                cboxDebitArticle.Refresh();
                cboxDebitArticle.Properties.Items.Clear();
                btnAddChildBudgetItem.Enabled = false;
                // очищаем список подстатей
                treelistBudgetItem.Nodes.Clear();
                txtDocMoney.Value = 0;
                txtDocMoney_Validated(txtDocMoney, new EventArgs());

                if (m_objBudget == null) { return; }

                // запрашиваем список статей бюджета
                if (m_objBudgetDoc.LoadPopupBudgetItemListForBudget(m_objProfile, m_objBudget) == true)
                {
                    foreach (ERP_Budget.Common.CPopupBudgetItem objPopupBudgetItem in m_objBudgetDoc.PopupBudgetItemList)
                    {
                        cboxDebitArticle.Properties.Items.Add(objPopupBudgetItem);
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
                cboxDebitArticle.Text = "";
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
                    if (objPopupBudgetItem.ChlildBudgetItemList.Count > 0)
                    {
                        foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in objPopupBudgetItem.ChlildBudgetItemList)
                        {
                            //if (objBudgetItem.uuidID.CompareTo(m_objBudgetDoc.BudgetItem.uuidID) == 0) { continue; }
                            DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                            treelistBudgetItem.AppendNode(new object[] { false, 
                                objBudgetItem.BudgetItemFullName, objBudgetItem.RestMoney, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, null);
                            objNode.Tag = objBudgetItem;
                            colBudgetItemName.Caption = "Подстатья";
                        }
                    }
                    else
                    {
                        DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                        treelistBudgetItem.AppendNode(new object[] { false, 
                                objPopupBudgetItem.ParentBudgetItem.BudgetItemFullName, objPopupBudgetItem.ParentBudgetItem.RestMoney, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, null);
                        objNode.Tag = objPopupBudgetItem.ParentBudgetItem;
                        colBudgetItemName.Caption = "Статья";
                    }
                    treelistBudgetItem.Enabled = (m_objBudgetDoc.Currency != null);
                    txtDocMoney.Value = 0;
                    txtDocMoney.Enabled = ((m_objBudgetDoc.Currency != null) && (treelistBudgetItem.Nodes.Count == 0));
                    txtDocMoney_Validated(txtDocMoney, new EventArgs());
                }
                if (treelistBudgetItem.Nodes.Count > 0)
                {
                    this.m_bWriteFromChildList = true;
                    //отключим старые месяцы
                    foreach (DevExpress.XtraTreeList.Columns.TreeListColumn objColumn in treelistBudgetItem.Columns)
                    {
                        if (objColumn.Tag == null) { continue; }
                        if (System.DateTime.Today.Month > ((System.Int32)objColumn.Tag))
                        {
                            objColumn.Visible = false;
                        }
                    }
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
        private void cboxDebitArticle_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (m_ViewDocVariant == enumViewDocVariant.NewDocument)
                {
                    if (e.NewValue.GetType() == typeof(System.String))
                    {
                        e.Cancel = !(((System.String)e.NewValue == strLoadText) || ((System.String)e.NewValue == ""));
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
                if (objNode == null) { return; }
                System.Decimal Money = 0;
                System.Decimal SumMoneyBudgetCurrency = 0;
                System.Decimal CurrencyRate = GetCurrencyRate(txtDocMoney.CurrencyCode);

                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn objColumn in objNode.TreeList.Columns)
                {
                    if (objColumn.Tag == null) { continue; }

                    Money = System.Convert.ToDecimal(objNode.GetValue(objColumn));
                    SumMoneyBudgetCurrency += Money;//( Money * CurrencyRate );
                }

                // прописываем поллученное значение в столбец "Итого"
                objNode.SetValue(colMoneySum, SumMoneyBudgetCurrency);
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
        private void treelistBudgetItem_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
                // если меняется значение в столбце "Январь"..."Декабрь", то пересчитаем значение в столбце "Итого"
                if (e.Column.Tag != null)
                {
                    // для объекта "Статья бюджета" внесем изменения в расшифровку
                    ERP_Budget.Common.CBudgetItem objBudgetItemSelect = (ERP_Budget.Common.CBudgetItem)e.Node.Tag;
                    ERP_Budget.Common.CBudgetItemDecode objBudgetItemDecode = objBudgetItemSelect.GetBudgetItemDecode((ERP_Budget.Common.enumMonth)e.Column.Tag);

                    System.Decimal CurrencyRate = GetCurrencyRate(txtDocMoney.CurrencyCode);
                    objBudgetItemDecode.Currency = m_objBudgetDoc.Currency;
                    objBudgetItemDecode.MoneyPlan = System.Convert.ToDouble(e.Node.GetValue(e.Column));
                    objBudgetItemDecode.MoneyPlanAccept = System.Convert.ToDouble(CurrencyRate) * objBudgetItemDecode.MoneyPlan;

                    objBudgetItemSelect.MoneyInBudgetCurrency = objBudgetItemSelect.GetMoneyAgreeSum();
                    objBudgetItemSelect.MoneyInBudgetDocCurrency = objBudgetItemSelect.GetMoneyPlanSum();

                    // пересчитаем столбец "Итого"
                    RecalcNodeSum(e.Node);
                }
                SetBudgetItemList(e.Column, e.Node);
                // пересчитаем сумму бюджетного документа
                RecalcDocMoney();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения значения в списке подстатей.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void repItemCalcEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                e.Cancel = false;
                if (e.NewValue != null)
                {
                    System.Decimal Money = System.Convert.ToDecimal(e.NewValue);
                    e.Cancel = (Money < 0) ? true : false;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения суммы возврата в списке подстатей.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void SetBudgetItemList(DevExpress.XtraTreeList.Columns.TreeListColumn objColumn,
            DevExpress.XtraTreeList.Nodes.TreeListNode objNode)
        {
            try
            {
                if (objColumn == colCheck)
                {
                    m_objBudgetDoc.BudgetItemList.Clear();
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objectNode in treelistBudgetItem.Nodes)
                    {
                        if (((System.Boolean)objectNode.GetValue(colCheck)) && (objectNode.Tag != null))
                        {
                            // эта подстатья выбрана
                            ERP_Budget.Common.CBudgetItem objBudgetItem = (ERP_Budget.Common.CBudgetItem)objectNode.Tag;
                            foreach (ERP_Budget.Common.CBudgetItemDecode objBudgetItemDecode in objBudgetItem.BudgetItemDecodeList)
                            {
                                if (objBudgetItemDecode.Currency == null)
                                {
                                    objBudgetItemDecode.Currency = m_objBudgetDoc.Currency;
                                }
                            }
                            m_objBudgetDoc.BudgetItemList.Add(objBudgetItem);
                        }
                    }
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
        /// Пересчитывает сумму документа на основании сумм в списке статей
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
                        foreach (DevExpress.XtraTreeList.Columns.TreeListColumn objColumn in treelistBudgetItem.Columns)
                        {
                            if (objColumn.Tag == null) { continue; }
                            objNode.SetValue(objColumn, 0);
                        }
                    }
                }
                else
                {
                    // подсчитаем сумму
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        if ((System.Boolean)objNode.GetValue(colCheck))
                        {

                            SumDocMoney += System.Convert.ToDecimal(((ERP_Budget.Common.CBudgetItem)objNode.Tag).GetMoneyPlanSum());
                        }
                    }
                }

                txtDocMoney.Value = SumDocMoney;
                txtDocMoney_Validated(txtDocMoney, new EventArgs());
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
                    tlaypnlDemand_3.RowStyles[1].SizeType = SizeType.Absolute;

                    tlaypnlDemand_3.RowStyles[0].Height = 0;
                    tlaypnlDemand_3.RowStyles[1].Height = 0;

                    tlaypnlDemand_3.RowStyles[0].SizeType = SizeType.Percent;
                    tlaypnlDemand_3.RowStyles[1].SizeType = SizeType.Percent;

                    tlaypnlDemand_3.RowStyles[0].Height = 50;
                    tlaypnlDemand_3.RowStyles[1].Height = 50;
                }
                else
                {
                    tlaypnlDemand_3.RowStyles[0].SizeType = SizeType.Absolute;
                    tlaypnlDemand_3.RowStyles[0].Height = 0;
                    tlaypnlDemand_3.RowStyles[1].SizeType = SizeType.Percent;
                    tlaypnlDemand_3.RowStyles[1].Height = 100;
                }
                txtDocMoney.Enabled = ((m_objBudgetDoc.Currency != null) && (treelistBudgetItem.Nodes.Count == 0));

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
                // прячем/отображаем столбцы в списке подстатей
                //foreach (DevExpress.XtraTreeList.Columns.TreeListColumn objColumn in treelistBudgetItem.Columns)
                //{
                //    if (objColumn == colRestMoney) { objColumn.Visible = m_objBudgetDoc.IsActive; }
                //    else { objColumn.Visible = true; }
                //}
                colBudgetItemName.VisibleIndex = 1;
                colMoney1.VisibleIndex = 3;
                colMoney2.VisibleIndex = 4;
                colMoney3.VisibleIndex = 5;
                colMoney4.VisibleIndex = 6;
                colMoney5.VisibleIndex = 7;
                colMoney6.VisibleIndex = 8;
                colMoney7.VisibleIndex = 9;
                colMoney8.VisibleIndex = 10;
                colMoney9.VisibleIndex = 11;
                colMoney10.VisibleIndex = 12;
                colMoney11.VisibleIndex = 13;
                colMoney12.VisibleIndex = 14;
                colMoneySum.VisibleIndex = 15;
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
                if ((Control)sender == txtDocDescription)
                {
                    // примечание
                    this.m_objBudgetDoc.Description = txtDocDescription.Text;
                }
                // меняем фон
                ChangeBackGrnd();
                // уведомляем мир о том, что свойсво заявки изменилось
                SimulateChangeBudgetDocPropertie(((Control)sender).Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка функции EditValueChanged.\nОбъект : " + ((Control)sender).Name + "\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((Control)sender == cboxCompany)
                {
                    // компания
                    if (cboxCompany.SelectedItem.GetType() == typeof(ERP_Budget.Common.CCompany))
                    {
                        m_objBudgetDoc.Company = (ERP_Budget.Common.CCompany)cboxCompany.SelectedItem;
                    }
                }
                if ((Control)sender == cboxPaymentType)
                {
                    // форма оплаты
                    if (cboxPaymentType.SelectedItem.GetType() == typeof(ERP_Budget.Common.CPaymentType))
                    {
                        m_objBudgetDoc.PaymentType = (ERP_Budget.Common.CPaymentType)cboxPaymentType.SelectedItem;
                    }
                }
                if ((Control)sender == cboxBudget)
                {
                    // бюджет
                    if (cboxBudget.SelectedItem.GetType() == typeof(ERP_Budget.Common.CBudget))
                    {
                        m_objBudget = (ERP_Budget.Common.CBudget)cboxBudget.SelectedItem;
                        m_objBudgetDoc.BudgetDep = m_objBudget.BudgetDep;
                        cboxBudgetDep.Properties.Items.Clear();
                        cboxBudgetDep.Properties.Items.Add(m_objBudgetDoc.BudgetDep);
                        cboxBudgetDep.SelectedItem = cboxBudgetDep.Properties.Items[0];
                        m_objBudgetDoc.BudgetItem = null;
                        m_objBudgetDoc.BudgetItemList.Clear();
                        // обновляем список статей расходов
                        RefreshDebitArticleList();
                    }
                }
                if ((Control)sender == cboxDebitArticle)
                {
                    // статья расходов
                    if (cboxDebitArticle.SelectedItem.GetType() == typeof(ERP_Budget.Common.CPopupBudgetItem))
                    {
                        ERP_Budget.Common.CPopupBudgetItem objPopupBudgetItem = (ERP_Budget.Common.CPopupBudgetItem)cboxDebitArticle.SelectedItem;
                        m_objBudgetDoc.BudgetItem = objPopupBudgetItem.ParentBudgetItem;
                        // остаток средств
                        m_objBudgetDoc.BudgetItem.RestMoney =
                                ERP_Budget.Common.CBudgetItem.GetParentBudgetItemBalans(m_objBudgetDoc.BudgetItem.uuidID,
                                m_objProfile);
                        txtRestMoneyDebitArticle.Visible = (m_ViewDocVariant != enumViewDocVariant.Arj);
                        txtRestMoneyDebitArticle.Text = System.String.Format("{0:N}", m_objBudgetDoc.BudgetItem.RestMoney) + " " +
                            ERP_Budget.Global.Consts.strCurrencyBudget;
                        // обновляет список подстатей
                        RefreshChildDebitArticleList(objPopupBudgetItem);
                        btnAddChildBudgetItem.Enabled = (m_objBudgetDoc.Currency != null);
                    }
                }
                if ((Control)sender == cboxCurrency)
                {
                    m_objBudgetDoc.Currency = (ERP_Budget.Common.CCurrency)cboxCurrency.SelectedItem;
                    treelistBudgetItem.Enabled = (m_objBudgetDoc.BudgetItem != null);
                    txtDocMoney.CurrencyCode = m_objBudgetDoc.Currency.CurrencyCode;
                    txtDocMoney.CurrencyCodeBudget = ERP_Budget.Global.Consts.strCurrencyBudget;
                    txtDocMoney.CurrencyRate = (txtDocMoney.CurrencyCode == txtDocMoney.CurrencyCodeBudget) ? 1 : GetCurrencyRate(txtDocMoney.CurrencyCode);
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistBudgetItem.Nodes)
                    {
                        if ((System.Boolean)objNode.GetValue(colCheck) == true)
                        {
                            RecalcNodeSum(objNode);
                        }
                    }
                    // пересмотреть верхний блок 2007.05.02
                    if (txtDocMoney.Text != "")
                    {
                        txtDocMoneyBudgetCurrency.Text = System.String.Format("{0:N}", txtDocMoney.GetValue()) + " " + txtDocMoney.CurrencyCodeBudget;
                    }
                    foreach (DevExpress.XtraTreeList.Columns.TreeListColumn objColumn in treelistBudgetItem.Columns)
                    {
                        if (objColumn.Tag == null) { continue; }
                        objColumn.OptionsColumn.ReadOnly = (txtDocMoney.CurrencyCode == "");
                        objColumn.OptionsColumn.AllowEdit = !(txtDocMoney.CurrencyCode == "");
                    }
                    btnAddChildBudgetItem.Enabled = (m_objBudgetDoc.BudgetItem != null);
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
        /// Изменяет фон элементов управления
        /// </summary>
        private void ChangeBackGrnd()
        {
            try
            {
                System.Drawing.Color WarningColor = System.Drawing.Color.PapayaWhip;
                System.Drawing.Color NormalColor = System.Drawing.SystemColors.Window;

                cboxBudget.BackColor = (cboxBudget.Text == "") ? WarningColor : NormalColor;
                cboxDebitArticle.BackColor = (cboxDebitArticle.Text == "") ? WarningColor : NormalColor;
                cboxCurrency.BackColor = (cboxCurrency.Text == "") ? WarningColor : NormalColor;
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
                // сумма документа
                InitControlForRouteVariable(txtDocMoney);
                // служба
                InitControlForRouteVariable(cboxBudgetDep);
                // статья расходов
                InitControlForRouteVariable(cboxDebitArticle);
                // форма оплаты
                InitControlForRouteVariable(cboxPaymentType);
                // компания
                InitControlForRouteVariable(cboxCompany);
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
        private void txtDocMoney_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                e.Cancel = false;
                if ((e.NewValue.ToString()) != "")
                {
                    if ((System.Convert.ToDouble(e.NewValue)) < 0)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка изменения суммы.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
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
                    this.tableLayoutPanel3.Controls.Remove(this.btnAttach);
                    System.Windows.Forms.Label lblAttach = new System.Windows.Forms.Label();
                    lblAttach.Name = "lblAttach";
                    lblAttach.Text = "Вложения: ";
                    lblAttach.Anchor = AnchorStyles.Left;
                    this.tableLayoutPanel3.Controls.Add(lblAttach, 0, 5);

                }
                else
                {
                    tableLayoutPanel3.RowStyles[tableLayoutPanel3.RowStyles.Count - 1].Height = 0;
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

        #region Создание подстатьи
        private void btnAddChildBudgetItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cboxDebitArticle.SelectedItem == null) || (cboxCurrency.SelectedItem == null))
                {
                    return;
                }
                frmDebitArticleEditor objfrmDebitArticleEditor = new frmDebitArticleEditor(this.m_objProfile);
                objfrmDebitArticleEditor.AddDebitArticleChild(m_objBudgetDoc.BudgetItem, m_objBudget, m_objBudgetDoc.Currency);
                if (objfrmDebitArticleEditor.DialogResult == DialogResult.OK)
                {
                    ERP_Budget.Common.CPopupBudgetItem objPopupBudgetItem = (ERP_Budget.Common.CPopupBudgetItem)cboxDebitArticle.SelectedItem;
                    objPopupBudgetItem.ChlildBudgetItemList.Add(objfrmDebitArticleEditor.BudgetItem);
                    RefreshChildDebitArticleList(objPopupBudgetItem);
                    //DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                    //treelistBudgetItem.AppendNode(new object[] { false, 
                    //    objfrmDebitArticleEditor.BudgetItem.BudgetItemFullName, 0, 
                    //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, null);
                    //objNode.Tag = objfrmDebitArticleEditor.BudgetItem;
                }
                objfrmDebitArticleEditor.Dispose();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Ошибка создания подстатьи расходов.\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        #endregion

        public void RefreshDebitArticleListForNewBudgetDocType()
        {
            return;
        }

    }
}
