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
    public partial class uctrlBudgetDocType : UserControl, IBudgetDocType
    {
        #region Переменные, свойства
        /// <summary>
        /// информация о владельце документа
        /// </summary>
        private System.String m_strInfo;
        /// <summary>
        /// выбранный тип документа
        /// </summary>
        private ERP_Budget.Common.CBudgetDocType m_objCurrentType;
        /// <summary>
        /// список возможных значений типа документа
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocType> m_objListPossibleTypes;
        /// <summary>
        /// список типов документов с условиями их выбора
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocTypeCondition> m_objListCondition;
        /// <summary>
        /// Ссылка на список переменных, влияющих на выбор маршрута
        /// </summary>
        private List<ERP_Budget.Common.CRouteVariable> m_objRouteVariableList;
        /// <summary>
        /// Ссылка на бюджетный документ
        /// </summary>
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;
        /// <summary>
        /// Ссылка на профайл
        /// </summary>
        private UniXP.Common.CProfile m_objProfile;
        private System.String m_strMainDynamicRight;
        private enumDocStateVariant m_objDocState;
        /// <summary>
        /// Поток для загрузки списка доступных типов документов
        /// </summary>
        private System.Threading.Thread thrLoadConditionForSelectBudgetDocType;
        /// <summary>
        /// Делегат для отрисовки выпадающего списка с типами документов
        /// </summary>
        /// <param name="objBudgetDocType"></param>
        public delegate void DrawTypesInComboBoxDelegate(ERP_Budget.Common.CBudgetDocType objBudgetDocType);
        public DrawTypesInComboBoxDelegate m_DrawTypesInComboBoxDelegate;
        /// <summary>
        /// Список динамических прав пользователя в предметной области "Бюджет"
        /// </summary>
        private List<ERP_Budget.Common.CDynamicRight> m_objUserDynamicRightList;

        #endregion

        #region События
        // Создаем закрытое экземплярное поле для блокировки синхронизации потоков
        private readonly Object m_eventLock = new Object();
        // Создаем закрытое поле, ссылающееся на заголовок списка делегатов
        private EventHandler<ChangeRouteVariableEventArgs> m_NewDocType;
        // Создаем в классе член-событие
        public event EventHandler<ChangeRouteVariableEventArgs> NewDocType
        {
            add
            {
                // берем закрытую блокировку и добавляем обработчик
                // (передаваемый по значению) в список делегатов
                lock (m_eventLock) { m_NewDocType += value; }
            }
            remove
            {
                // берем закрытую блокировку и удаляем обработчик
                // (передаваемый по значению) из списка делегатов
                lock (m_eventLock) { m_NewDocType -= value; }
            }
        }
        /// <summary>
        /// Инициирует событие и уведомляет о нем зарегистрированные объекты
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnNewDocType(ChangeRouteVariableEventArgs e)
        {
            // Сохраняем поле делегата во временном поле для обеспечение безопасности потока
            EventHandler<ChangeRouteVariableEventArgs> temp = m_NewDocType;
            // Если есть зарегистрированные объектв, уведомляем их
            if (temp != null) temp(this, e);
        }
        public void SimulateNewBudgetDoc(ERP_Budget.Common.CRouteVariable objRouteVariable)
        {
            // Создаем объект, хранящий информацию, которую нужно передать
            // объектам, получающим уведомление о событии
            ChangeRouteVariableEventArgs e = new ChangeRouteVariableEventArgs(objRouteVariable);

            // Вызываем виртуальный метод, уведомляющий наш объект о возникновении события
            // Если нет типа, переопределяющего этот метод, наш объект уведомит все объекты, 
            // подписавшиеся на уведомление о событии
            OnNewDocType(e);
        }
        #endregion

        #region Конструкторы
        public uctrlBudgetDocType()
        {
            InitializeComponent();

            m_strInfo = "";
            m_objCurrentType = null;
            m_objListPossibleTypes = null;
            m_objListCondition = null;
            m_objRouteVariableList = null;
            m_objBudgetDoc = null;
            m_objProfile = null;
            m_objDocState = enumDocStateVariant.Unkown;
            m_strMainDynamicRight = "";
            m_objUserDynamicRightList = null;
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="objProfile">ссылка на профайл</param>
        /// <param name="strInfo">инфо</param>
        /// <param name="objInitBudgetDocTypeVariableList">ссылка на список переменных, влияющих на выбор типа документа</param>
        /// <param name="objRouteVariableList">Ссылка на список переменных, влияющих на выбор маршрута</param>
        /// <param name="objBudgetDoc">ссылка на заявку</param>
        /// <param name="objDocStateVariant">состояние документа</param>
        public uctrlBudgetDocType(UniXP.Common.CProfile objProfile, System.String strInfo,
            List<ERP_Budget.Common.CRouteVariable> objRouteVariableList,
            ERP_Budget.Common.CBudgetDoc objBudgetDoc, enumDocStateVariant objDocStateVariant,
            System.String strDR, ERP_Budget.Common.CBudgetDocType objBudgetDocType,
            List<ERP_Budget.Common.CBudgetDocTypeCondition> objListCondition,
            List<ERP_Budget.Common.CDynamicRight> objUserDynamicRightList)
        {
            InitializeComponent();

            m_strInfo = strInfo;
            m_objProfile = objProfile;
            m_objCurrentType = objBudgetDocType;
            m_objListPossibleTypes = null;
            m_objListCondition = objListCondition;
            m_objBudgetDoc = objBudgetDoc;
            m_objDocState = objDocStateVariant;
            m_objRouteVariableList = objRouteVariableList;
            m_objUserDynamicRightList = objUserDynamicRightList;
            m_strMainDynamicRight = strDR;
        }
        /// <summary>
        /// Инициализирует значения переменных на основании входных данных в конструкторе
        /// </summary>
        /// <param name="objInitBudgetDocTypeVariableList">ссылка на список переменных, влияющих на выбор типа документа</param>
        public void InitVariables(List<ERP_Budget.Common.CBudgetDocTypeVariable> objInitBudgetDocTypeVariableList)
        {
            try
            {
                DrawInfoAboutOwnerBudgetDoc();

                if (m_objDocState == enumDocStateVariant.NewDocument)
                {
                    // новый бюджетный документ, необходимо отслеживать изменение типа документа
                    // и фильтровать список допустимых значений типа документа

                    txtDR4DocType.Text = m_strMainDynamicRight;
                    txtDeficitMoney.Text = "0";
                    if (objInitBudgetDocTypeVariableList != null)
                    {
                        // тип бюджетного документа
                        // инициализация переменной, влияющей на выбор типа документа, данными из списка с динамическими правами пользователя
                        ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariable = objInitBudgetDocTypeVariableList.FirstOrDefault<ERP_Budget.Common.CBudgetDocTypeVariable>(x => x.EditClassName.IndexOf(txtDR4DocType.GetType().Name) == 0);
                        if (objDocTypeVariable != null) 
                        {
                            if ((m_objUserDynamicRightList != null) && (m_objUserDynamicRightList.Count > 1))
                            {
                                // у пользователя несколько динамических прав в предметной области
                                // необходимо дополнить список переменных, влияющих на выбор маршрута
                                List<ERP_Budget.Common.CBudgetDocTypeVariable> objBudgetDocTypeVariableListForDynamicRight = new List<ERP_Budget.Common.CBudgetDocTypeVariable>();
                                foreach (ERP_Budget.Common.CDynamicRight objRight in m_objUserDynamicRightList)
                                {
                                    if ((objRight.Name == m_strMainDynamicRight) ||
                                        (objRight.Name == ERP_Budget.Global.Consts.strDRCreateUndefinedDocument))
                                    {
                                        // 20130719
                                        // в плане эксперимента загружать буду не все динамические права, а MainDynamicRight 
                                        // и "Прочее", если оно назначено пользователю
                                        objBudgetDocTypeVariableListForDynamicRight.Add(new ERP_Budget.Common.CBudgetDocTypeVariable()
                                        {
                                            uuidID = objDocTypeVariable.m_uuidID,
                                            Name = objDocTypeVariable.Name,
                                            PatternSrc = objDocTypeVariable.PatternSrc,
                                            Pattern = objDocTypeVariable.Pattern,
                                            EditClassName = objDocTypeVariable.EditClassName,
                                            DataTypeName = objDocTypeVariable.DataTypeName,
                                            m_strValue = objRight.Name
                                        });
                                    }
                                }
                                objInitBudgetDocTypeVariableList.Remove(objDocTypeVariable);
                                objInitBudgetDocTypeVariableList.AddRange(objBudgetDocTypeVariableListForDynamicRight);
                            }
                            else
                            {
                                objDocTypeVariable.m_strValue = txtDR4DocType.GetValue();
                            }
                        }

                        // дефицит средств
                        ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariableDeficit = objInitBudgetDocTypeVariableList.SingleOrDefault<ERP_Budget.Common.CBudgetDocTypeVariable>(x => x.EditClassName.IndexOf(txtDeficitMoney.GetType().Name) == 0);
                        if (objDocTypeVariableDeficit != null) { objDocTypeVariableDeficit.m_strValue = txtDeficitMoney.GetValue(); }
                    }
                    // маршрут будет меняться и нужно это отслеживать
                    BindRouteVariablesWithControls();

                    // список условий выбора типа документа 
                    if (m_objListCondition == null)
                    {
                        m_objListCondition = ERP_Budget.Common.CBudgetDocTypeCondition.GetDocTypeConditionList(m_objProfile);
                    }
                    // запрашиваем список типов документов согласно проинициализированных переменных
                    m_objListPossibleTypes = ERP_Budget.Common.CBudgetDocTypeConditionAlgoritm.GetBudgetDocTypeList(
                        objInitBudgetDocTypeVariableList, m_objListCondition);

                    DrawTypesInComboBox(m_objCurrentType);

                    //// загружается список типов документов и условиями, 
                    //// при выполнении которых тип документа попадает в разряд "Доступен для использования"

                    //// инициализируем делегат для отрисовки выпадающего списка с типами документов
                    //m_DrawTypesInComboBoxDelegate = null;
                    //m_DrawTypesInComboBoxDelegate = new DrawTypesInComboBoxDelegate(DrawTypesInComboBox);

                    //// запуск потока с запросом условий выбора типа документа
                    //this.thrLoadConditionForSelectBudgetDocType = new System.Threading.Thread(() => InitBudgetDocTypeConditionList(m_objProfile, objInitBudgetDocTypeVariableList));
                    //this.thrLoadConditionForSelectBudgetDocType.Start();
                }
                else
                {
                    txtDocType.Enabled = false;
                    // тип документа меняться не будет, информацию о нем получим из ссылки на бюджетный документ
                    if (m_objBudgetDoc == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Не удалось определить тип документа.\nОбъект \"Заявка не найден\"!\nОбратитесь к системному администратору.", "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    else
                    {
                        m_objCurrentType = m_objBudgetDoc.DocType;
                        txtDocType.Properties.Items.Add(m_objCurrentType);
                        if (m_objListPossibleTypes == null)
                        {
                            txtDocType.SelectedItem = txtDocType.Properties.Items[0];
                        }
                        else
                        {
                            txtDocType.SelectedItem = m_objListPossibleTypes[0];
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitVariables\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// Загружает список условий для выбора допустимых типов бюджетного документа
        /// </summary>
        /// <param name="objProfile">профайл</param>
        /// <returns>true-операция прошла успешно; false - ошибка либо список условий пуст</returns>
        public void InitBudgetDocTypeConditionList(UniXP.Common.CProfile objProfile,
            List<ERP_Budget.Common.CBudgetDocTypeVariable> objInitBudgetDocTypeVariableList)
        {
            try
            {
                // список условий выбора типа документа 
                m_objListCondition = ERP_Budget.Common.CBudgetDocTypeCondition.GetDocTypeConditionList(objProfile);

                // запрашиваем список типов документов согласно проинициализированных переменных
                m_objListPossibleTypes = ERP_Budget.Common.CBudgetDocTypeConditionAlgoritm.GetBudgetDocTypeList(
                    objInitBudgetDocTypeVariableList, m_objListCondition);
                
                // отрисовка выпадающего списка
                this.Invoke(m_DrawTypesInComboBoxDelegate, new Object[] { m_objCurrentType });
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitBudgetDocTypeConditionList\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void InitBudgetDocTypeVariableList(List<ERP_Budget.Common.CBudgetDocTypeVariable> objInitBudgetDocTypeVariableList)
        {
            try
            {
                if (objInitBudgetDocTypeVariableList != null)
                {
                    // документ новый, начальные установки для выбора типа документ
                    txtDR4DocType.Text = m_strMainDynamicRight;
                    txtDeficitMoney.Text = "0";

                    // теперь в списке переменных, влияющих на выбор типа документа,
                    // найдем те, которые связаны с txtDR4DocType и txtDeficitMoney

                    ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariable = objInitBudgetDocTypeVariableList.SingleOrDefault<ERP_Budget.Common.CBudgetDocTypeVariable>(x=>x.EditClassName.IndexOf(txtDR4DocType.GetType().Name ) == 0);
                    if( objDocTypeVariable != null ) { objDocTypeVariable.m_strValue = txtDR4DocType.GetValue(); }

                    ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariableDeficit = objInitBudgetDocTypeVariableList.SingleOrDefault<ERP_Budget.Common.CBudgetDocTypeVariable>(x=>x.EditClassName.IndexOf(txtDeficitMoney.GetType().Name) == 0);
                    if( objDocTypeVariableDeficit != null ) { objDocTypeVariableDeficit.m_strValue = txtDeficitMoney.GetValue(); }


                    // на основании списка переменных, влиящих на выбор типа документа,
                    // создадим список доступных типов
                    LoadPossibleListTypes(objInitBudgetDocTypeVariableList);
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "InitBudgetDocTypeVariableList\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
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
                if ((m_objRouteVariableList == null) || (m_objRouteVariableList.Count == 0)) { return; }

                // если в списке есть переменная, связанная с классом элемента управления objControl,
                // то этот элемент управления будет влиять на выбор маршрута

                if (m_objRouteVariableList.FirstOrDefault<ERP_Budget.Common.CRouteVariable>(x => x.EditClassName.IndexOf(txtDocType.GetType().Name) == 0) != null)
                {
                    txtDocType.TextChanged += new EventHandler(this.RouteVariable_TextChanged);
                }

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
        /// Обработчик изменения текста  в элементе управления, который связан с переменной, влияющей на выбор маршрута
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteVariable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // в элементе управления, связанном с переменной, влияющей на выбор маршрута, был изменён текст
                // необходимо изменить значение переменной и дать знать всем подписавшимся на это событие, что оно произошло

                if ((m_objRouteVariableList == null) || (m_objRouteVariableList.Count == 0)) { return; }

                Control objControl = (Control)sender;
                ERP_Budget.Common.CRouteVariable objRouteVariable = m_objRouteVariableList.FirstOrDefault<ERP_Budget.Common.CRouteVariable>(x => x.EditClassName.IndexOf(objControl.GetType().Name) == 0);
                if (objRouteVariable  != null)
                {
                    objRouteVariable.m_strPreviousValue = objRouteVariable.m_strValue;
                    objRouteVariable.m_strValue = ((ERP_Budget.Common.IRouteVariableEdit)objControl).GetValue();

                    if (objRouteVariable.m_strPreviousValue != objRouteVariable.m_strValue)
                    {
                        SimulateNewBudgetDoc( objRouteVariable );
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

        #region LoadPossibleListTypes
        /// <summary>
        /// Обновляет список доступных типов бюджетного документа
        /// </summary>
        /// <param name="objInitBudgetDocTypeVariableList">список переменных, влияющих на выбор типа документа</param>
        public void LoadPossibleListTypes(
            List<ERP_Budget.Common.CBudgetDocTypeVariable> objInitBudgetDocTypeVariableList)
        {
            m_objListPossibleTypes = null;
            try
            {
                // запрашиваем список типов документов согласно проинициализированных переменных
                m_objListPossibleTypes = ERP_Budget.Common.CBudgetDocTypeConditionAlgoritm.GetBudgetDocTypeList(
                    objInitBudgetDocTypeVariableList, m_objListCondition);
                // заполняем значения в выпадающем списке типов документа
                DrawTypesInComboBox(m_objCurrentType);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления списка допустимых значений типа документа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        #endregion

        #region SetCurrentType
        /// <summary>
        /// Принудительно устанавливает текущее значение типа бюджетного документа
        /// </summary>
        /// <param name="objBudgetDoctype">тип бюджетного документа</param>
        public void SetCurrentType(ERP_Budget.Common.CBudgetDocType objBudgetDoctype)
        {
            try
            {
                if (objBudgetDoctype == null)
                {
                    return;
                }
                System.Int32 iIndx = -1;
                for (System.Int32 i = 0; i < txtDocType.Properties.Items.Count; i++)
                {
                    if (((ERP_Budget.Common.CBudgetDocType)txtDocType.Properties.Items[i]).uuidID == objBudgetDoctype.uuidID)
                    {
                        iIndx = i;
                        break;
                    }
                }
                if (iIndx >= 0)
                {
                    txtDocType.SelectedItem = txtDocType.Properties.Items[iIndx];
                    txtDocType_EditValueChanged(txtDocType, new EventArgs());
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка метода 'SetCurrentType'.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        #endregion

        #region GetCurrentType
        public ERP_Budget.Common.CBudgetDocType GetCurrentType()
        {
            return m_objCurrentType;
        }
        #endregion

        #region SelectFirstDocType
        /// <summary>
        /// Принудительно устанавливает первый из списка возможных значений типа бюджетного документа
        /// </summary>
        public void SelectFirstDocType()
        {
            try
            {
                if (txtDocType.Properties.Items.Count > 0)
                {
                    txtDocType.SelectedItem = txtDocType.Properties.Items[0];
                    m_objCurrentType = (ERP_Budget.Common.CBudgetDocType)txtDocType.Properties.Items[0];
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка метода 'SelectFirstDocType'.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }

            return;
        }
        #endregion

        #region DrawTypesInComboBox
        /// <summary>
        /// Отрисовывает список допустимых значений
        /// </summary>
        /// <param name="objBudgetDocType">тип документа, который нужно выбрать</param>
        public void DrawTypesInComboBox(ERP_Budget.Common.CBudgetDocType objBudgetDocType)
        {
            try
            {
                //this.tableLayoutPanel1.SuspendLayout();

                // список типов документов пуст
                if ((m_objListPossibleTypes == null) || (m_objListPossibleTypes.Count == 0))
                {
                    txtDocType.Text = "";
                    txtDocType.Properties.Items.Clear();
                }
                else
                {
                    // обновляем выпадающий список
                    txtDocType.Properties.Items.Clear();
                    System.Boolean bFind = false;
                    foreach (ERP_Budget.Common.CBudgetDocType objDocType in m_objListPossibleTypes)
                    {
                        txtDocType.Properties.Items.Add(objDocType);
                        if ((objBudgetDocType != null) && (objDocType.uuidID.CompareTo(objBudgetDocType.uuidID) == 0))
                        {
                            bFind = true;
                            txtDocType.SelectedItem = objDocType;
                            m_objBudgetDoc.DocType = (ERP_Budget.Common.CBudgetDocType)txtDocType.SelectedItem;
                            m_objBudgetDoc.BudgetDocCategory = m_objBudgetDoc.DocType.BudgetDocCategory;
                        }
                    }

                    if ((objBudgetDocType == null) || (bFind == false))
                    {
                        System.Boolean bNeedSetFirstType = false;
                        if (m_objCurrentType == null)
                        {
                            bNeedSetFirstType = true;
                        }
                        else
                        {
                            if (m_objListPossibleTypes.Contains(m_objCurrentType) == false)
                            {
                                // ранее выбранный тип документа не входит в список допустимых типов документов
                                bNeedSetFirstType = true;
                            }
                            else
                            {
                                // проверим, возможно есть более приоритетный тип
                                if (m_objListPossibleTypes.IndexOf(m_objCurrentType) > 0)
                                {
                                    bNeedSetFirstType = true;
                                }
                            }
                        }

                        if (bNeedSetFirstType == true)
                        {
                            if (m_objCurrentType == null)
                            {
                                txtDocType.SelectedItem = txtDocType.Properties.Items[0];
                                m_objBudgetDoc.DocType = (ERP_Budget.Common.CBudgetDocType)txtDocType.SelectedItem;
                                m_objBudgetDoc.BudgetDocCategory = m_objBudgetDoc.DocType.BudgetDocCategory;
                            }
                            else
                            {
                                if (txtDocType.SelectedItem != txtDocType.Properties.Items[0])
                                {
                                    txtDocType.SelectedItem = txtDocType.Properties.Items[0];
                                    m_objBudgetDoc.DocType = (ERP_Budget.Common.CBudgetDocType)txtDocType.SelectedItem;
                                    m_objBudgetDoc.BudgetDocCategory = m_objBudgetDoc.DocType.BudgetDocCategory;
                                }
                            }
                        }
                    }

                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления информации в списке типов документа.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                //this.tableLayoutPanel1.ResumeLayout(false);

            }
            return;
        }
        #endregion

        #region DrawInfoAboutOwnerBudgetDoc
        /// <summary>
        /// Отрисовывает информацию о владельце бюджетного документа
        /// </summary>
        private void DrawInfoAboutOwnerBudgetDoc()
        {
            try
            {
                lblDocCaption.Text = m_strInfo;
                txtBudgetDocCategoryName.Text = ( ( m_objBudgetDoc.BudgetDocCategory != null ) ? m_objBudgetDoc.BudgetDocCategory.Name : "" );
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Не удалось отобразить информацию о создателе заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
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
                "Не удалось отобразить информацию о создателе заявки.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void DrawIcon()
        {
            try
            {
                if ((txtDocType.Properties.Items.Count > 0) || (txtDocType.Text != ""))
                {
                    if (this.m_objCurrentType.BudgetDocTypeDraw != null)
                    {
                        pictureEdit.Image = this.m_objCurrentType.BudgetDocTypeDraw.ImageDocType;
                    }
                }
                else
                {
                    pictureEdit.Image = null;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка метода 'txtDocType_EditValueChanged'.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        private void txtDocType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                System.String strErr = System.String.Empty;
                if (txtDocType.Properties.Items.Count > 0)
                {
                    if (txtDocType.SelectedItem.GetType().ToString() == "ERP_Budget.Common.CBudgetDocType")
                    {
                        m_objCurrentType = (ERP_Budget.Common.CBudgetDocType)txtDocType.SelectedItem;

                        if (m_objBudgetDoc.DocType == null)
                        {
                            m_objBudgetDoc.DocType = m_objCurrentType;
                        }
                        else
                        {
                            if ((m_objCurrentType != null) && (m_objCurrentType.uuidID.CompareTo(m_objBudgetDoc.DocType.uuidID) != 0))
                            {
                                m_objBudgetDoc.DocType = m_objCurrentType;
                            }
                        }

                        if ((m_objBudgetDoc.DocType != null) && ((m_objBudgetDoc.DocType.ValidBudgetTypeList == null) || (m_objBudgetDoc.DocType.ValidBudgetTypeList.Count == 0)))
                        {
                            // загрузка списка допустимых типов бюджетов
                            m_objBudgetDoc.DocType.ValidBudgetTypeList = ERP_Budget.Common.CBudgetTypeDataBaseModel.GetValidBudgetTypeList(m_objBudgetDoc.DocType.uuidID, m_objProfile, null, ref strErr);
                        }

                        txtBudgetDocCategoryName.Text = ((m_objBudgetDoc.DocType != null) ? (String.Format("[{0}]", m_objBudgetDoc.DocType.BudgetDocCategoryName)) : "");

                        SizeF stringSize = new SizeF();

                        System.Drawing.Graphics g = txtDocType.CreateGraphics();

                        stringSize = g.MeasureString(txtDocType.Text, txtDocType.Font);
                        tableLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.lblDocCaption.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.txtDocType.Properties)).BeginInit();
                        this.txtDocType.Size = new System.Drawing.Size( System.Convert.ToInt32(stringSize.Width + 30), 20);
                        
                        tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Absolute;
                        tableLayoutPanel1.ColumnStyles[1].Width = System.Convert.ToInt32(stringSize.Width + 30);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.lblDocCaption.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.txtDocType.Properties)).EndInit();
                        tableLayoutPanel1.Refresh();
                        this.Size = new Size(this.Size.Width+1, this.Size.Height);
                        this.Refresh();

                        DrawIcon();
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка метода 'txtDocType_EditValueChanged'.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }


    }


}
