using System;
using System.Collections.Generic;
using System.Text;

namespace ErpBudgetBudgetDoc
{
    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public partial class ChangeRouteVariableEventArgs : EventArgs
    {
        private readonly ERP_Budget.Common.CRouteVariable m_objRouteVariable;
        public ERP_Budget.Common.CRouteVariable RouteVariable
        { get { return m_objRouteVariable; } }

        public ChangeRouteVariableEventArgs(ERP_Budget.Common.CRouteVariable objRouteVariable)
        {
            m_objRouteVariable = objRouteVariable;
        }
    }

    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public partial class ChangeBudgetDocPropertieEventArgs : EventArgs
    {
        private readonly System.String m_strPropertieName;
        public System.String PropertieName
        { get { return m_strPropertieName; } }

        public ChangeBudgetDocPropertieEventArgs(System.String strPropertieName)
        {
            m_strPropertieName = strPropertieName;
        }
    }
    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public partial class ChangeDocTypeVariableEventArgs : EventArgs
    {
        private readonly ERP_Budget.Common.CBudgetDocTypeVariable m_objDocTypeVariable;
        public ERP_Budget.Common.CBudgetDocTypeVariable DocTypeVariable
        { get { return m_objDocTypeVariable; } }

        public ChangeDocTypeVariableEventArgs(ERP_Budget.Common.CBudgetDocTypeVariable objDocTypeVariable)
        {
            m_objDocTypeVariable = objDocTypeVariable;
        }
    }
    /// <summary>
    /// Тип, хранящий информацию, которая передается получателям уведомления о событии
    /// </summary>
    public partial class ChangeHideBtnStateEventArgs : EventArgs
    {
        private readonly System.String m_strControlName;
        public System.String ControlName
        { get { return m_strControlName; } }

        private readonly System.Boolean m_bCanShow;
        public System.Boolean CanShow
        { get { return m_bCanShow; } }

        private readonly System.Int32 m_iBtnHeight;
        public System.Int32 BtnHeight
        { get { return m_iBtnHeight; } }

        public ChangeHideBtnStateEventArgs(
            System.String strControlName, System.Boolean bCanShow, System.Int32 iBtnHeight)
        {
            m_bCanShow = bCanShow;
            m_strControlName = strControlName;
            m_iBtnHeight = iBtnHeight;
        }
    }

}
