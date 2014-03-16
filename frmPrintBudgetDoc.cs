using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
    public partial class frmPrintBudgetDoc : DevExpress.XtraEditors.XtraForm
    {
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;
        private UniXP.Common.CProfile m_objProfile;
        public frmPrintBudgetDoc( ERP_Budget.Common.CBudgetDoc objBudgetDoc,
             UniXP.Common.CProfile objProfile )
        {
            this.m_objBudgetDoc = objBudgetDoc;
            this.m_objProfile = objProfile;

            AppDomain currentDomain = AppDomain.CurrentDomain;

            currentDomain.AssemblyResolve += new ResolveEventHandler( MyResolveEventHandler );
            InitializeComponent();
        }

        private System.Reflection.Assembly MyResolveEventHandler( object sender, ResolveEventArgs args )
        {
            System.Reflection.Assembly MyAssembly = null;
            System.Reflection.Assembly objExecutingAssemblies = System.Reflection.Assembly.GetExecutingAssembly();

            System.Reflection.AssemblyName[] arrReferencedAssmbNames=objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            System.String strDllName = "";
            foreach( System.Reflection.AssemblyName strAssmbName in arrReferencedAssmbNames )
            {

                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if( strAssmbName.FullName.Substring( 0, strAssmbName.FullName.IndexOf( "," ) ) == args.Name.Substring( 0, args.Name.IndexOf( "," ) ) )
                {
                    strDllName = args.Name.Substring( 0, args.Name.IndexOf( "," ) ) + ".dll";
                    break;
                }

            }
            if( strDllName != "" )
            {
                System.String strFileFullName = "";
                System.Boolean bError = false;
                foreach( System.String strPath in this.m_objProfile.ResourcePathList )
                {
                    //Load the assembly from the specified path. 
                    strFileFullName = strPath + "\\" + strDllName;
                    if( System.IO.File.Exists( strFileFullName ) )
                    {
                        try
                        {
                            MyAssembly = System.Reflection.Assembly.LoadFrom( strFileFullName );
                            break;
                        }
                        catch( System.Exception f )
                        {
                            bError = true;
                            DevExpress.XtraEditors.XtraMessageBox.Show( "Ошибка загрузки библиотеки: " + 
                                strFileFullName + "\n\nТекст ошибки: " + f.Message, "Ошибка",
                                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
                        }
                    }
                    if( bError ) { break; }
                }
            }

            //Return the loaded assembly.
            if( MyAssembly == null )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( "Не удалось найти библиотеку: " + 
                                strDllName, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning );

            }
            return MyAssembly;
        }
        private void RefreshPrintList()
        {
            try
            {
                this.treeList.Nodes.Clear();
                this.memoEdit.Text = "";
                System.String strmemoEditText = "";
                if( this.m_objBudgetDoc == null ) { return; }

                // Тип документа
                if( this.m_objBudgetDoc.DocType != null )
                {
                    this.treeList.AppendNode( new object[] { this.m_objBudgetDoc.DocType.Name, null }, null );
                    strmemoEditText += ( this.m_objBudgetDoc.DocType.Name );
                }
                // инициатор
                if( this.m_objBudgetDoc.OwnerUser != null )
                {
                    this.treeList.AppendNode( new object[] { "Инициатор", ( this.m_objBudgetDoc.OwnerUser.UserLastName + " " + this.m_objBudgetDoc.OwnerUser.UserFirstName ) }, null );
                    strmemoEditText += ( "\r\nИнициатор:\t\t" +( this.m_objBudgetDoc.OwnerUser.UserLastName + " " + this.m_objBudgetDoc.OwnerUser.UserFirstName ) );
                }
                // дата
                if( this.m_objBudgetDoc.Date != null )
                {
                    this.treeList.AppendNode( new object[] { "Дата создания", this.m_objBudgetDoc.Date.ToLongDateString() }, null );
                    strmemoEditText += ( "\r\nДата создания:\t\t" + this.m_objBudgetDoc.Date.ToLongDateString() );
                }
                // Служба
                if( this.m_objBudgetDoc.BudgetDep != null )
                {
                    this.treeList.AppendNode( new object[] { "Служба", this.m_objBudgetDoc.BudgetDep.Name }, null );
                    strmemoEditText += ( "\r\nСлужба:\t\t\t" + this.m_objBudgetDoc.BudgetDep.Name );
                }
                // Компания
                if( this.m_objBudgetDoc.Company != null )
                {
                    this.treeList.AppendNode( new object[] { "Компания", this.m_objBudgetDoc.Company.CompanyAcronym }, null );
                    strmemoEditText += ( "\r\nКомпания:\t\t" + this.m_objBudgetDoc.Company.CompanyAcronym );
                }
                // Форма расчетов
                if( this.m_objBudgetDoc.PaymentType != null )
                {
                    this.treeList.AppendNode( new object[] { "Форма расчетов", this.m_objBudgetDoc.PaymentType.Name }, null );
                    strmemoEditText += ( "\r\nФорма расчетов:\t\t" + this.m_objBudgetDoc.PaymentType.Name );
                }
                // Состояние
                if( this.m_objBudgetDoc.DocState != null )
                {
                    this.treeList.AppendNode( new object[] { "Состояние", this.m_objBudgetDoc.DocState.Name }, null );
                    strmemoEditText += ( "\r\nСостояние:\t\t" + this.m_objBudgetDoc.DocState.Name );
                }
                // Срок платежа
                if( this.m_objBudgetDoc.PaymentDate != null )
                {
                    this.treeList.AppendNode( new object[] { "Срок платежа", this.m_objBudgetDoc.PaymentDate.ToLongDateString() }, null );
                    strmemoEditText += ( "\r\nСрок платежа:\t\t" + this.m_objBudgetDoc.PaymentDate.ToLongDateString() );
                }
                // Статья расходов
                if( this.m_objBudgetDoc.BudgetItem != null )
                {
                    this.treeList.AppendNode( new object[] { "Статья расходов", this.m_objBudgetDoc.BudgetItem.BudgetItemFullName }, null );
                    strmemoEditText += ( "\r\nСтатья расходов:\t\t" + this.m_objBudgetDoc.BudgetItem.BudgetItemFullName );
                }
                // Сумма
                if( this.m_objBudgetDoc.Currency != null )
                {
                    this.treeList.AppendNode( new object[] { "Сумма", ( System.String.Format( "{0:#### ###.00}", this.m_objBudgetDoc.Money ) + " " + this.m_objBudgetDoc.Currency.CurrencyCode ) }, null );
                    strmemoEditText += ( "\r\nСумма:\t\t\t" + ( System.String.Format( "{0:#### ###.00}", this.m_objBudgetDoc.Money ) + " " + this.m_objBudgetDoc.Currency.CurrencyCode ) );
                }
                // Получатель средств
                if( this.m_objBudgetDoc.Recipient != null )
                {
                    this.treeList.AppendNode( new object[] { "Получатель средств", this.m_objBudgetDoc.Recipient }, null );
                    strmemoEditText += ( "\r\nПолучатель средств:\t" + this.m_objBudgetDoc.Recipient );
                }
                // Описание цели
                if( this.m_objBudgetDoc.Objective != null )
                {
                    this.treeList.AppendNode( new object[] { "Описание цели", this.m_objBudgetDoc.Objective }, null );
                    strmemoEditText += ( "\r\nОписание цели:\t\t" + this.m_objBudgetDoc.Objective );
                }
                // Документальное основание
                if( this.m_objBudgetDoc.DocBasis != null )
                {
                    this.treeList.AppendNode( new object[] { "Документальное основание", this.m_objBudgetDoc.DocBasis }, null );
                    strmemoEditText += ( "\r\nДокументальное основание:\t\t" + this.m_objBudgetDoc.DocBasis );
                }
                // Примечание
                if( this.m_objBudgetDoc.Description != null )
                {
                    this.treeList.AppendNode( new object[] { "Примечание", this.m_objBudgetDoc.Description }, null );
                    strmemoEditText += ( "\r\nПримечание:\t\t" + this.m_objBudgetDoc.Description );
                }
                this.memoEdit.Text = strmemoEditText;
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка загрузки данных в форму печати.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }

        #region Открытие формы
        private void frmPrintBudgetDoc_Load( object sender, EventArgs e )
        {
            try
            {
                RefreshPrintList();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка открытия формы печати.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        #region Печать
        private void barBtnPrint_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if( DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable )
                    DevExpress.XtraPrinting.PrintHelper.ShowPreview( treeList );
                else
                    MessageBox.Show( "XtraPrinting Library is not found...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                Cursor.Current = Cursors.Default;
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( "Ошибка печати.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        #region Закрытие формы
        private void barBtnClose_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                this.Close();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка закрытия формы печати.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion


    }
}