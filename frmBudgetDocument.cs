using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;


namespace ErpBudgetBudgetDoc
{
    /// <summary>
    /// Варианты отображения документа
    /// </summary>
    public enum enumDocStateVariant
    {
        Unkown = 0,
        NewDocument = 1,    // Новая заявка
        SavedDocument = 2,  // Сохраненный документ
        ArjDocument = 3     // Неактивный документ

    }

    public partial class frmBudgetDocument : DevExpress.XtraEditors.XtraForm
    {
        #region Переменные, Свойства, Константы
        /// <summary>
        /// Ссылка на профайл
        /// </summary>
        private UniXP.Common.CProfile m_objProfile;
        /// <summary>
        /// объект заявка
        /// </summary>
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;
        /// <summary>
        /// объект "Заявка"
        /// </summary>
        public ERP_Budget.Common.CBudgetDoc BudgetDoc
        {
            get { return m_objBudgetDoc; }
        }
        /// <summary>
        /// объект "Текущий пользователь"
        /// </summary>
        private ERP_Budget.Common.CUser m_objCurrentUser;
        /// <summary>
        /// список переменных, влияющих на выбор маршрута
        /// </summary>
        private List<ERP_Budget.Common.CRouteVariable> m_objRouteVariableList;
        /// <summary>
        /// список маршрутов с условиями их выбора
        /// </summary>
        private List<ERP_Budget.Common.CRouteCondition> m_objRouteTemplateList;
        /// <summary>
        /// список переменных, влияющих на выбот типа документа 
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocTypeVariable> m_objDocTypeVariableList;
        /// <summary>
        /// список типов документов с условиями их выбора
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocTypeCondition> m_objBudgetDocTypeTemplateList;
        /// <summary>
        /// Состояние документа
        /// </summary>
        private enumDocStateVariant m_objDocStateVariant;
        /// <summary>
        /// Динамическое право
        /// </summary>
        private System.String m_strMainDR;
        /// <summary>
        /// Выбранное действие над бюджетным документом
        /// </summary>
        private ERP_Budget.Common.CBudgetDocEvent m_objSelectedEvent;
        /// <summary>
        /// Следующее состояние бюджетного документа
        /// </summary>
        private ERP_Budget.Common.CBudgetDocState m_objNextDocState;
        /// <summary>
        /// Признак того, закончит ли бюджетный документ свой маршрут после свершения действия над ним
        /// </summary>
        private System.Boolean m_bIsEndRoute;
        /// <summary>
        /// Список динамических прав пользователя в предметной области "Бюджет"
        /// </summary>
        private List<ERP_Budget.Common.CDynamicRight> m_objUserDynamicRightList;

        private uctrlBudgetDocType m_objCtrlBudgetDocType;
        private uctrlBudgetDocRoute m_objCtrlBudgetDocRoute;
        private uctrlBudgetDocEvent m_objCtrlBudgetDocEvent;
        private IBudgetDoc m_objCtrlBudgetDoc;

        private const System.Int32 iDocEventPnlHeight = 70;
        private const System.Int32 iDocRoutePnlHeight = 80;
        private const System.String strDemandClass = "ErpBudgetBudgetDoc.uctrlBudgetDocDemand";
        private const System.String strBackMoneyClass = "ErpBudgetBudgetDoc.uctrlBudgetDocBackMoney";
        private const System.String strChangeBudgetItemClass = "ErpBudgetBudgetDoc.uctrlBudgetDocChangeBudgetItem";

        #endregion

        public frmBudgetDocument(UniXP.Common.CProfile objProfile,
            List<ERP_Budget.Common.CRouteVariable> objRouteVariableList,
            List<ERP_Budget.Common.CBudgetDocTypeVariable> objDocTypeVariableList,
            ERP_Budget.Common.CUser objCurrentUser, ERP_Budget.Common.CBudgetDoc objBudgetDoc,
            List<ERP_Budget.Common.CRouteCondition> objRouteTemplateList,
            List<ERP_Budget.Common.CBudgetDocTypeCondition> objBudgetDocTypeTemplateList,
            List<ERP_Budget.Common.CDynamicRight> objUserDynamicRightList)
        {
            InitializeComponent();

            m_objProfile = objProfile;
            m_objRouteVariableList = objRouteVariableList;
            m_objDocTypeVariableList = objDocTypeVariableList;
            m_objCurrentUser = objCurrentUser;
            m_objCtrlBudgetDocType = null;
            m_objCtrlBudgetDocRoute = null;
            m_objCtrlBudgetDocEvent = null;
            m_objCtrlBudgetDoc = null;
            m_objSelectedEvent = null;
            m_objNextDocState = null;
            m_bIsEndRoute = false;
            m_strMainDR = ERP_Budget.Common.CDynamicRight.GetMainDynamicRight(m_objProfile, null);
            m_objBudgetDoc = objBudgetDoc;
            m_objRouteTemplateList = objRouteTemplateList;
            m_objBudgetDocTypeTemplateList = objBudgetDocTypeTemplateList;
            m_objUserDynamicRightList = objUserDynamicRightList;
        }

        public void OpenBudgetDoc()
        {
            System.Int32 iRet = 0;
            System.String strErr = System.String.Empty;

            try
            {
                if (m_objBudgetDoc == null)
                {
                    m_objBudgetDoc = new ERP_Budget.Common.CBudgetDoc() { uuidID = System.Guid.NewGuid(), IsActive = true, OwnerUser = m_objCurrentUser };
                    m_objDocStateVariant = enumDocStateVariant.NewDocument;
                }
                else
                {
                    m_objDocStateVariant = (m_objBudgetDoc.IsActive == true) ? enumDocStateVariant.SavedDocument : enumDocStateVariant.ArjDocument;
                }

                this.tableLayoutPanelBase.SuspendLayout();

                // формирование раздела "Тип документа"
                InitBudgetDocTypePnl(null);

                if (m_objBudgetDoc.DocType == null) { return; }

                // формирование раздела "Маршрут" 
                InitRoutePnl( ref iRet, ref strErr );

                InitDocEventPnl();
                InitDocPropertiePnl();

                switch (m_objDocStateVariant)
                {
                    case enumDocStateVariant.NewDocument:
                        m_objCtrlBudgetDoc.bOpenBudgetDoc();
                        CheckDocumentProperties();
                        break;
                    case enumDocStateVariant.SavedDocument:
                        m_objCtrlBudgetDoc.bOpenBudgetDoc();
                        CheckDocumentProperties();
                        break;
                    case enumDocStateVariant.ArjDocument:
                        m_objCtrlBudgetDoc.bOpenBudgetDoc();
                        barBtnSave.Enabled = false;
                        tableLayoutPanelBase.RowStyles[2].Height = 0;
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OpenBudgetDoc.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                this.tableLayoutPanelBase.ResumeLayout(false);
                this.tableLayoutPanelBase.PerformLayout();

            }

            return;
        }
        /// <summary>
        /// Копирует бюджетный документ
        /// </summary>
        /// <param name="objBudgetDocSrc">исходный бюджетный документ</param>
        public void CopyBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDocSrc)
        {
            System.Int32 iRet = 0;
            System.String strErr = System.String.Empty;

            try
            {
                m_objBudgetDoc = new ERP_Budget.Common.CBudgetDoc();
                m_objBudgetDoc.uuidID = System.Guid.NewGuid();
                m_objBudgetDoc.IsActive = true;
                m_objBudgetDoc.OwnerUser = m_objCurrentUser;
                m_objDocStateVariant = enumDocStateVariant.NewDocument;

                // создаем панель "Тип документа и прописываем нужный тип"
                InitBudgetDocTypePnl(objBudgetDocSrc.DocType);
                if (m_objBudgetDoc.DocType == null) { return; }
                // создаем панель "Маршрут"
                InitRoutePnl( ref iRet, ref strErr );
                // создаем панель "Действия"
                InitDocEventPnl();

                // теперь нужно подгрузить правильную панель свойств
                InitDocPropertiePnl();
                if (m_objCtrlBudgetDocType.GetCurrentType().ControlClassName != objBudgetDocSrc.DocType.ControlClassName)
                {
                    // был выбран тип настолько отличный от типа исходного бюджетного документа,
                    // что у них отличаются панели свойств
                    // поэтому копировать мы не будем, а просто создадим новый документ
                    m_objCtrlBudgetDoc.bOpenBudgetDoc();
                }
                else
                {
                    m_objCtrlBudgetDoc.CopyBudgetDoc(objBudgetDocSrc);
                }
                // проверим свойства бюджетного документа
                CheckDocumentProperties();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка копирования бюджетного документа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Создает панель "Тип документа"
        /// </summary>
        /// <param name="objBudgetDocType">тип документа, кторый нужно выбрать</param>
        private void InitBudgetDocTypePnl(ERP_Budget.Common.CBudgetDocType objBudgetDocType)
        {
            try
            {
                System.String strInfo = String.Format(" от {0} {1}  дата: {2}", 
                    m_objBudgetDoc.OwnerUser.UserLastName, m_objBudgetDoc.OwnerUser.UserFirstName, m_objBudgetDoc.Date.ToShortDateString());

                m_objCtrlBudgetDocType = new uctrlBudgetDocType( m_objProfile, strInfo, 
                    m_objRouteVariableList, m_objBudgetDoc,
                    m_objDocStateVariant, m_strMainDR, objBudgetDocType,
                    m_objBudgetDocTypeTemplateList, m_objUserDynamicRightList);

                if (m_objCtrlBudgetDocType != null)
                {
                    tableLayoutPanelBase.Controls.Add(m_objCtrlBudgetDocType, 0, 0);

                    m_objCtrlBudgetDocType.DrawControl();

                    m_objCtrlBudgetDocType.InitVariables(m_objDocTypeVariableList);
                    

                    if (m_objDocStateVariant == enumDocStateVariant.NewDocument)
                    {
                        m_objCtrlBudgetDocType.NewDocType += OnChangeRouteVariable;
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitBudgetDocTypePnl.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Создает панель "Маршрут"
        /// </summary>
        private void InitRoutePnl(ref System.Int32 iRet, ref System.String strErr)
        {
            try
            {
                m_objCtrlBudgetDocRoute = new uctrlBudgetDocRoute(m_objBudgetDoc, m_strMainDR, 
                    ERP_Budget.Common.CUserBudgetRights.GetUserBudgetRightsList(m_objProfile, null, 0), 
                    m_objRouteTemplateList);

                if( m_objCtrlBudgetDocRoute != null )
                {
                    m_objCtrlBudgetDocRoute.LoadConditionForSelectRoute(m_objProfile, m_objRouteVariableList, ref iRet, ref strErr);
                    if (iRet == 0)
                    {
                        tableLayoutPanelBase.Controls.Add(m_objCtrlBudgetDocRoute, 0, 1);
                        m_objCtrlBudgetDocRoute.DrawControl();
                        m_objCtrlBudgetDocRoute.ChangeHideBtn += this.OnChangeHideBtnState;

                        if (m_objDocStateVariant == enumDocStateVariant.NewDocument)
                        {
                            m_objCtrlBudgetDocRoute.ChangeRoute += this.OnChangeRoute;
                            m_objCtrlBudgetDocRoute.HideControl();
                        }
                        else
                        {
                            m_objCtrlBudgetDocRoute.RouteDraw(m_objBudgetDoc.Route.RoutePointList, false);
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                iRet = -1;
                strErr += ("InitRoutePnl. Текст ошибки: " + f.Message);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Создает панель "Действия"
        /// </summary>
        private void InitDocEventPnl()
        {
            try
            {
                if (m_objDocStateVariant == enumDocStateVariant.ArjDocument)
                {
                    return;
                }
                m_objCtrlBudgetDocEvent = new uctrlBudgetDocEvent();
                tableLayoutPanelBase.Controls.Add(m_objCtrlBudgetDocEvent, 0, 2);
                m_objCtrlBudgetDocEvent.DrawControl();
                if (m_objDocStateVariant == enumDocStateVariant.NewDocument)
                {
                    m_objCtrlBudgetDocEvent.ChangeDocEven += this.OnChangeDocEvent;
                    m_objCtrlBudgetDocEvent.ChangeHideBtn += this.OnChangeHideBtnState;
                    m_objCtrlBudgetDocEvent.HideControl();
                }
                else
                {
                    m_objCtrlBudgetDocEvent.CreateEventList(m_objBudgetDoc.Route.RoutePointList,
                        m_objCurrentUser, m_objBudgetDoc.DocState, m_objProfile, m_objBudgetDoc);
                    m_objCtrlBudgetDocEvent.ChangeHideBtn += this.OnChangeHideBtnState;
                    if (m_objCtrlBudgetDocEvent.GetEventCount() > 0)
                    {
                        m_objCtrlBudgetDocEvent.ChangeDocEven += this.OnChangeDocEvent;
                    }
                    else
                    {
                        m_objCtrlBudgetDocEvent.HideControl();
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitDocEventPnl.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Создает панель "Документ"
        /// </summary>
        private void InitDocPropertiePnl()
        {
            try
            {
                CreateDocPropertiePnl(GetNeedPropertiePnlName(), new Point(0, 0), 0, 0);
                if (m_objDocStateVariant == enumDocStateVariant.NewDocument)
                {
                    m_objCtrlBudgetDoc.ChangeRouteVariable += OnChangeRouteVariable;
                    m_objCtrlBudgetDoc.ChangeDocTypeVariable += OnChangeDocType;
                    m_objCtrlBudgetDoc.ChangeBudgetDocPropertie += OnChangeDocPropertie;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitDocPropertiePnl.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Возвращает имя класса для отображения свойств бюджетного документа
        /// </summary>
        /// <returns>имя класса для отображения свойств бюджетного документа</returns>
        private System.String GetNeedPropertiePnlName()
        {
            System.String strRet = "";
            try
            {
                if (m_objBudgetDoc.DocType == null) { return strRet; }
                strRet = m_objBudgetDoc.DocType.ControlClassName;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось определить объект \"Свойства документа\".\nGetPropertiePnlName()\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return strRet;
        }
        /// <summary>
        /// Создает объект класса для отображения свойств бюджетного документа
        /// </summary>
        /// <param name="strDocPropertieClassName">имя класса для отображения свойств бюджетного документа</param>
        private void CreateDocPropertiePnl(System.String strDocPropertieClassName,
            System.Drawing.Point LocationPoint, System.Int32 iWidth, System.Int32 iHeight)
        {
            try
            {
                if (strDocPropertieClassName == "")
                {
                    return;
                }

                System.Boolean bisActionUser = true;
                System.Boolean bNeedEvent = false;
                if (m_objDocStateVariant == enumDocStateVariant.NewDocument)
                {
                    bisActionUser = true;
                }
                else
                {
                    if (m_objDocStateVariant == enumDocStateVariant.ArjDocument)
                    {
                        bisActionUser = false;
                    }
                    else
                    {
                        if (m_objDocStateVariant == enumDocStateVariant.SavedDocument)
                        {
                            if (m_objCtrlBudgetDocEvent.GetEventCount() > 0)
                            {
                                bisActionUser = true;
                                bNeedEvent = true;
                            }
                            else
                            {
                                bisActionUser = false;
                                // проверим предыдущую точку маршрута
                                foreach (ERP_Budget.Common.CRoutePoint objRoutePoint in m_objBudgetDoc.Route.RoutePointList)
                                {
                                    if (objRoutePoint.BudgetDocStateOUT.uuidID.CompareTo(m_objBudgetDoc.DocState.uuidID) == 0)
                                    {
                                        // нашли, проверим кто числится в этой точке
                                        if (objRoutePoint.UserEvent.ulID == m_objCurrentUser.ulID)
                                        {
                                            // текущий пользователь и найденный совпадают
                                            bisActionUser = true;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (strDocPropertieClassName == strDemandClass)
                {
                    m_objCtrlBudgetDoc = new uctrlBudgetDocDemand(m_objProfile, m_objBudgetDoc,
                        m_objRouteVariableList, m_objDocTypeVariableList, m_objDocStateVariant,
                        m_strMainDR, m_strMainDR, bisActionUser, bNeedEvent);
                }
                if (strDocPropertieClassName == strBackMoneyClass)
                {
                    m_objCtrlBudgetDoc = new uctrlBudgetDocBackMoney(m_objProfile, m_objBudgetDoc,
                        m_objRouteVariableList, m_objDocStateVariant, ERP_Budget.Global.Consts.strDRCashier,
                        ERP_Budget.Global.Consts.strDRCashier, bisActionUser);
                }
                if (strDocPropertieClassName == strChangeBudgetItemClass)
                {
                    m_objCtrlBudgetDoc = new uctrlBudgetDocChangeBudgetItem(m_objProfile, m_objBudgetDoc,
                        m_objRouteVariableList, m_objDocStateVariant, m_strMainDR, m_strMainDR, bisActionUser);
                }
                ((UserControl)m_objCtrlBudgetDoc).Location = LocationPoint;
                ((UserControl)m_objCtrlBudgetDoc).Width = iWidth;
                ((UserControl)m_objCtrlBudgetDoc).Height = iHeight;
                tableLayoutPanelBase.Controls.Add((UserControl)m_objCtrlBudgetDoc, 0, 3);
                m_objCtrlBudgetDoc.DrawControl();

                if (bisActionUser == false)
                {
                    barBtnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка создания объекта \"Свойства документа\".\nCreateDocPropertiePnl().\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        private void ChangeDocPropertiePnl()
        {
            try
            {
                System.String strNeedDemandType = GetNeedPropertiePnlName();
                m_objBudgetDoc.IsResetBudgetItem = false;

                if ((m_objBudgetDoc.DocType != null) && (m_objDocStateVariant == enumDocStateVariant.NewDocument))
                {
                    System.String strDocPropertieClassName = m_objCtrlBudgetDoc.GetType().ToString();
                    if (strDocPropertieClassName != strNeedDemandType)
                    {
                        // класс для отображения свойств документа отличается от текущего

                        tableLayoutPanelBase.SuspendLayout();

                        m_objBudgetDoc.Route = null;
                        m_objBudgetDoc.BudgetItem = null;
                        m_objBudgetDoc.BudgetItemList.Clear();
                        m_objBudgetDoc.Currency = null;
                        m_objBudgetDoc.Company = null;
                        m_objBudgetDoc.BudgetDep = null;
                        m_objBudgetDoc.PaymentType = null;
                        m_objBudgetDoc.Money = 0;
                        m_objBudgetDoc.MoneyAgree = 0;
                        m_objBudgetDoc.Description = "";
                        m_objBudgetDoc.Objective = "";
                        m_objBudgetDoc.Recipient = "";
                        m_objBudgetDoc.DocBasis = "";

                        System.Int32 iX = ((UserControl)m_objCtrlBudgetDoc).Location.X;
                        System.Int32 iY = ((UserControl)m_objCtrlBudgetDoc).Location.Y;
                        System.Int32 iWidth = ((UserControl)m_objCtrlBudgetDoc).Width;
                        System.Int32 iHeight = ((UserControl)m_objCtrlBudgetDoc).Height;

                        tableLayoutPanelBase.Controls.Remove((UserControl)m_objCtrlBudgetDoc);
                        m_objCtrlBudgetDoc = null;
                        CreateDocPropertiePnl(strNeedDemandType, new Point(iX, iY), iWidth, iHeight);

                        m_objCtrlBudgetDoc.ChangeRouteVariable += OnChangeRouteVariable;
                        m_objCtrlBudgetDoc.ChangeDocTypeVariable += OnChangeDocType;
                        m_objCtrlBudgetDoc.ChangeBudgetDocPropertie += OnChangeDocPropertie;

                        m_objCtrlBudgetDocRoute.ClearRoute();

                        m_objCtrlBudgetDoc.bOpenBudgetDoc();
                        CheckDocumentProperties();

                        tableLayoutPanelBase.ResumeLayout(false);
                        //tableLayoutPanelBase.Refresh();
                    }
                    else
                    {
                        // класс для отображения документа прежний, но необходимо отфтильтровать список доступных бюджетов
                        m_objCtrlBudgetDoc.RefreshDebitArticleListForNewBudgetDocType();
                    }
                }


            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "ChangeDocPropertiePnl.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }

        #region События

        #region Маршрут
        private void OnChangeRouteVariable(Object sender, ChangeRouteVariableEventArgs e)
        {
            try
            {
                if (m_objDocStateVariant == enumDocStateVariant.NewDocument)
                {
                    // изменилась переменная, влияющая на выбор маршрута
                    // попробуем изменить маршрут 
                    if (m_objCtrlBudgetDocRoute != null)
                    {
                        System.String strDynamicRightForBudgetDep = "";
                        if ((m_objBudgetDoc != null) && (m_objBudgetDoc.BudgetDep != null))
                        {
                            strDynamicRightForBudgetDep = ERP_Budget.Common.CDynamicRight.GetMainDynamicRight(m_objProfile, m_objBudgetDoc.BudgetDep);
                        }
                        else
                        {
                            strDynamicRightForBudgetDep = m_strMainDR;
                        }
                        m_objCtrlBudgetDocRoute.SelectRoute(m_objRouteVariableList, strDynamicRightForBudgetDep);
                    }

                    // по ходу это мог поменяться тип документа
                    if (e.RouteVariable.Name == "Тип документа")
                    {
                        // создание панели со свойствами бюджетного документа в зависимости от значения нового типа документа
                        ChangeDocPropertiePnl();
                    }
                }
                CheckDocumentProperties();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangeRouteVariable.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        private void OnChangeRoute(Object sender, ChangeRouteEventArgs e)
        {
            try
            {
                // свойства маршрут изменились
                // он или новый, или изменился пользователь в точке
                if (m_objBudgetDoc.Route == null)
                {
                    m_objBudgetDoc.Route = new ERP_Budget.Common.CBudgetRoute();
                    m_objBudgetDoc.Route.BudgetDocID = m_objBudgetDoc.uuidID;
                }
                if (e.RouteIsFull == true)
                {
                    //m_objBudgetDoc.Route.RoutePointList = null;
                    m_objBudgetDoc.Route.RoutePointList.Clear();
                    List<ERP_Budget.Common.CRoutePoint> objRoutePointList = m_objCtrlBudgetDocRoute.GetRoutePointList();
                    foreach (ERP_Budget.Common.CRoutePoint objRoutePoint in objRoutePointList)
                    {
                        m_objBudgetDoc.Route.RoutePointList.Add(objRoutePoint);
                    }

                    m_objCtrlBudgetDocRoute.ShowOptimizeBtn(e.CanOptimize); 
                    // попробуем оптимизировать
                    if (ERP_Budget.Common.CRouteTemplate.Optimize(m_objBudgetDoc.Route.RoutePointList) == true)
                    {
                        m_objCtrlBudgetDocRoute.RouteDraw(m_objBudgetDoc.Route.RoutePointList, false);
                        m_objCtrlBudgetDocRoute.SetRouteTmplToNull();
                    }
                    else
                    {
                        //  с оптимизацией ничего не вышло, возвращаем все назад
                        m_objBudgetDoc.Route.RoutePointList.Clear();
                        foreach (ERP_Budget.Common.CRoutePoint objRoutePoint in objRoutePointList)
                        {
                            m_objBudgetDoc.Route.RoutePointList.Add(objRoutePoint);
                        }
                    }
                }
                else
                {
                    m_objBudgetDoc.Route.RoutePointList = null;
                    m_objCtrlBudgetDocRoute.ShowOptimizeBtn(false);
                }
                //нужно отрисовать список возможных действий
                if (m_objCtrlBudgetDocEvent != null)
                {
                    if (e.RouteIsSelected == true)
                    {
                        m_objCtrlBudgetDocEvent.CreateEventList(m_objBudgetDoc.Route.RoutePointList,
                            m_objCurrentUser, m_objBudgetDoc.DocState, m_objProfile, m_objBudgetDoc);
                    }
                    else
                    {
                        //нужно очистить список возможных действий
                        m_objCtrlBudgetDocEvent.ClearEventList();
                    }
                }
                CheckDocumentProperties();
                //DevExpress.XtraEditors.XtraMessageBox.Show(e.RouteIsFull.ToString(), "Внимание",
                //System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangeRoute.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        #endregion

        /// <summary>
        /// Обработчик события, возникающего при изменении действия, совершаемого над бюджетным документом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangeDocEvent(Object sender, ChangeDocEvenEventArgs e)
        {
            try
            {
                if ((m_objBudgetDoc != null) && (m_objCtrlBudgetDocEvent != null))
                {
                    m_objSelectedEvent = e.BudgetDocEvent;
                    if (m_objSelectedEvent != null)
                    {
                        // определим, в какое состояние перейдет бюджетный документ в результате этого действия
                        SetNextDocState(m_objSelectedEvent);
                    }
                }
                CheckDocumentProperties();
                //DevExpress.XtraEditors.XtraMessageBox.Show("Выбрано действие: '" + e.BudgetDocEvent.Name + "'", "Внимание",
                //System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangeDocEvent.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Определяет состояние, в которое перейдет документ, в результате дейсвия objDocEvent
        /// </summary>
        /// <param name="objDocEvent">действие</param>
        private void SetNextDocState(ERP_Budget.Common.CBudgetDocEvent objDocEvent)
        {
            try
            {
                if ((objDocEvent == null) || (m_objBudgetDoc == null) || (m_objBudgetDoc.Route == null) ||
                    (m_objBudgetDoc.Route.RoutePointList.Count == 0)) { m_objNextDocState = null; }
                else
                {
                    foreach (ERP_Budget.Common.CRoutePoint objRoutePoint in m_objBudgetDoc.Route.RoutePointList)
                    {
                        if (m_objBudgetDoc.DocState == null)
                        {
                            if (objRoutePoint.BudgetDocStateIN == null)
                            {
                                // нашли точку маршрута с нужным начальным состоянием и действием
                                m_objNextDocState = objRoutePoint.BudgetDocStateOUT;
                                m_bIsEndRoute = objRoutePoint.IsExit;
                                break;
                            }
                        }
                        else
                        {
                            if (objRoutePoint.BudgetDocStateIN == null) { continue; }
                            if ((objRoutePoint.BudgetDocStateIN.uuidID.CompareTo(m_objBudgetDoc.DocState.uuidID) == 0) &&
                                (objRoutePoint.BudgetDocEvent.uuidID.CompareTo(objDocEvent.uuidID) == 0))
                            {
                                // нашли точку маршрута с нужным начальным состоянием и действием
                                m_objNextDocState = objRoutePoint.BudgetDocStateOUT;
                                m_bIsEndRoute = objRoutePoint.IsExit;
                                break;
                            }
                        }

                    }
                    if (m_objNextDocState == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Не удалось определить следующее состояние заявки!", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось определить состояние, \nв которое перейдет документ.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void OnChangeDocType(Object sender, ChangeDocTypeVariableEventArgs e)
        {
            try
            {
                // была изменена переменная, влияющая на выбор типа документа
                if (e.DocTypeVariable != null)
                {
                    // передадим в панель "Тип документа" список проинициализированных переменных
                    // для фильтрации списка возможных значений
                    m_objCtrlBudgetDocType.LoadPossibleListTypes(m_objDocTypeVariableList);
                }
                CheckDocumentProperties();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangeDocType.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }

        private void OnChangeDocPropertie(Object sender, ChangeBudgetDocPropertieEventArgs e)
        {
            try
            {
                CheckDocumentProperties();
                //DevExpress.XtraEditors.XtraMessageBox.Show("Изменено свойство: '" + e.PropertieName + "'", "Внимание",
                //System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangeDocEvent.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }
        /// <summary>
        /// Проверка свойств бюджетного документа
        /// </summary>
        private void CheckDocumentProperties()
        {
            // необходимо проверить свойства документа, что бы определить, можно ли отправлять его по маршруту
            // если можно, то включаем кнопку "Отправить", если нет, то делаем ее неактивной
            System.Boolean bOk = false;
            try
            {
                if ((m_objBudgetDoc != null) && ((m_objDocStateVariant == enumDocStateVariant.NewDocument) ||
                    (m_objDocStateVariant == enumDocStateVariant.SavedDocument)))
                {
                    // документ активен
                    // проверим обязательные поля, тип документа и маршрут
                    bOk = m_objBudgetDoc.IsReadyForSave;
                    // если создан объект "Действия" и в нем определен список этих действий,
                    // то проверим, выбрано ли какое-нибудь из них
                    if (bOk == true)
                    {
                        if ((m_objCtrlBudgetDocEvent != null) && (m_objCtrlBudgetDocEvent.GetEventCount() > 0))
                        {
                            bOk = (m_objSelectedEvent != null);
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangeDocEvent.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                if ((bOk == true) && (barBtnSave.Enabled == false)) 
                {
                    ToolTipControllerShowEventArgs args = CreateShowArgs();
                    this.Refresh();
                    toolTipSend.ShowHint(args, new Point(this.Location.X + 20, this.Location.Y + 20));
                }
                barBtnSave.Enabled = bOk;
            }

            return;
        }
        private ToolTipControllerShowEventArgs CreateShowArgs()
        {
            ToolTipControllerShowEventArgs args = toolTipSend.CreateShowArgs();
            args.ToolTip = "Документ заполнен и готов к отправке";
            args.Title = "Отправить";
            //args.IconType = ToolTipIconType.Information;
            //args.IconSize = ToolTipIconSize.Small;
            args.ToolTipImage = ErpBudgetBudgetDoc.Properties.Resources.mail_preferences;
            //args.ImageIndex = 0;
            args.ToolTipLocation = ToolTipLocation.BottomRight;
            return args;
        }
        /// <summary>
        /// Обработчик события "Спрятать/показать" панель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChangeHideBtnState(Object sender, ChangeHideBtnStateEventArgs e)
        {
            try
            {
                System.Int32 iMinHeight = e.BtnHeight + 13;
                if (e.ControlName == "uctrlBudgetDocRoute")
                {
                    tableLayoutPanelBase.RowStyles[1].Height = (e.CanShow) ? iMinHeight : iDocRoutePnlHeight;
                    m_objCtrlBudgetDocRoute.DrawControl();
                }

                if (e.ControlName == "uctrlBudgetDocEvent")
                {
                    tableLayoutPanelBase.RowStyles[2].Height = (e.CanShow) ? iMinHeight : iDocEventPnlHeight;
                }
                //DevExpress.XtraEditors.XtraMessageBox.Show("Изменено свойство: '" + e.PropertieName + "'", "Внимание",
                //System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "OnChangeHideBtnState.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
            }

            return;
        }

        #endregion

        #region Отправить по маршруту
        /// <summary>
        /// Сохраняет в БД бюджетный документ
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        private System.Boolean SaveBudgetDoc()
        {
            System.Boolean bRet = false;
            ERP_Budget.Common.CBudgetDoc.ViewDocVariantCondition objViewDocVariantCondition = null;
            try
            {
                objViewDocVariantCondition = GetDocVariantCondition();

                if (objViewDocVariantCondition != null)
                {
                    bRet = true;
                    if(m_objDocStateVariant == enumDocStateVariant.NewDocument)
                    {
                        if (m_objBudgetDoc.Division == true)
                        {
                            bRet = m_objCtrlBudgetDoc.ReorganizeDocSum();
                        }
                        else
                        {
                            bRet = m_objCtrlBudgetDoc.ConfirmBudgetDocMoney();
                            if (bRet == false)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(
                                "Подтвердите сумму в заявке.", "Внимание",
                                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                                return bRet;
                            }
                        }
                    }


                    if (bRet == true)
                    {
                        bRet = m_objBudgetDoc.bSendBudgetDoc(objViewDocVariantCondition, m_objProfile);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка сохранения бюджетного документа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                objViewDocVariantCondition = null;
            }
            return bRet;
        }

        /// <summary>
        /// возвращает структуру, с помощью которой далее определим,
        /// какие действия необходимо проделать с заявкой 
        /// </summary>
        /// <returns></returns>
        ERP_Budget.Common.CBudgetDoc.ViewDocVariantCondition GetDocVariantCondition()
        {
            ERP_Budget.Common.CBudgetDoc.ViewDocVariantCondition objRet = new ERP_Budget.Common.CBudgetDoc.ViewDocVariantCondition();
            try
            {
                //if ( m_objDocStateVariant == enumDocStateVariant.NewDocument )
                //{
                //    //objRet.BudgetDocSrcID = this.m_uuidBudgetDocSrc;
                //}
                objRet.DocState = m_objBudgetDoc.DocState;
                objRet.BudgetDep = m_objBudgetDoc.BudgetDep;
                objRet.IsActive = true;
                objRet.DocType = m_objBudgetDoc.DocType;
                objRet.DocEvent = m_objSelectedEvent;
                objRet.NextDocState = m_objNextDocState;
                objRet.IsEndRoute = m_bIsEndRoute;
                objRet.Owner = m_objBudgetDoc.OwnerUser;
                objRet.CurrentUser = m_objCurrentUser;
                objRet.DynamicRight = ERP_Budget.Common.CDynamicRight.Init(m_objProfile, m_strMainDR);
                objRet.AdvancedRight = m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRAddRight);
                objRet.BudgetDocSrcID = m_objBudgetDoc.SrcDocID;
            }
            catch (System.Exception f)
            {
                objRet = null;
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось определить параметры отправки заявки по маршруту.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return objRet;
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (SaveBudgetDoc())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка сохранения бюджетного документа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region Печать
        private void barBtnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                frmPrintBudgetDoc objfrmPrintBudgetDoc = new frmPrintBudgetDoc(m_objBudgetDoc, m_objProfile);
                objfrmPrintBudgetDoc.ShowDialog();
                objfrmPrintBudgetDoc.Dispose();

                Cursor.Current = Cursors.Default;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка печати\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Закрытие формы
        private void frmBudgetDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((m_objCtrlBudgetDoc != null) && (m_objCtrlBudgetDoc.GetOpenDocFlag()))
                {
                    // нужно пометить заявку, что она закрыта
                    if (m_objBudgetDoc.SetOpenPropertie(false, m_objProfile) == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Не удалось сделать пометку о закрытии заявки.", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка закрытия заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Открытие формы
        private void frmBudgetDocument_Shown(object sender, EventArgs e)
        {
            if (m_objCtrlBudgetDoc != null)
            {
                m_objCtrlBudgetDoc.SetFocus();
            }
        }
        #endregion


    }
}
