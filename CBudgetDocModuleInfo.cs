using System;
using System.Collections.Generic;
using System.Text;

namespace ErpBudgetBudgetDoc
{
    public class CBudgetDocModuleClassInfo : UniXP.Common.CModuleClassInfo
    {
        public CBudgetDocModuleClassInfo()
        {
            UniXP.Common.CLASSINFO objClassInfo;
            // журнал бюджетных документов
            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ErpBudgetBudgetDoc.ViewBudgetDocList";
            objClassInfo.strName = "Заявки";
            objClassInfo.strDescription = "Модуль для работы с бюджетными документами";
            objClassInfo.lID = 0;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_BUDGETDOCSMALL";
            m_arClassInfo.Add( objClassInfo );

            // журнал бюджетных документов
            objClassInfo = new UniXP.Common.CLASSINFO();
            objClassInfo.enClassType = UniXP.Common.EnumClassType.mcView;
            objClassInfo.strClassName = "ErpBudgetBudgetDoc.BudgetDocListManage";
            objClassInfo.strName = "Заявки (управление)";
            objClassInfo.strDescription = "Модуль для управления бюджетными документами";
            objClassInfo.lID = 1;
            objClassInfo.nImage = 1;
            objClassInfo.strResourceName = "IMAGES_BUDGETDOCSMALL";
            m_arClassInfo.Add( objClassInfo );
        }
    }

    public class CBudgetDocModuleInfo : UniXP.Common.CClientModuleInfo
    {
        public CBudgetDocModuleInfo()
            : base( System.Reflection.Assembly.GetExecutingAssembly(),
            UniXP.Common.EnumDLLType.typeItem,
            new System.Guid( "{31E0E1EA-DB5C-4076-A783-5FAEDA0B3EAA}" ),
            new System.Guid( "{a8e694df-15a3-4713-80ac-304b3fe911e8}" ),
            ErpBudgetBudgetDoc.Properties.Resources.IMAGES_BUDGETDOC,
            ErpBudgetBudgetDoc.Properties.Resources.IMAGES_BUDGETDOCSMALL )
        {
        }

        /// <summary>
        /// Выполняет операции по проверке правильности установки модуля в системе.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Check( UniXP.Common.CProfile objProfile )
        {
            return true;
        }
        /// <summary>
        /// Выполняет операции по установке модуля в систему.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Install( UniXP.Common.CProfile objProfile )
        {
            return true;
        }
        /// <summary>
        /// Выполняет операции по удалению модуля из системы.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean UnInstall( UniXP.Common.CProfile objProfile )
        {
            return true;
        }
        /// <summary>
        /// Производит действия по обновлению при установке новой версии подключаемого модуля.
        /// </summary>
        /// <param name="objProfile">Профиль пользователя.</param>
        public override System.Boolean Update( UniXP.Common.CProfile objProfile )
        {
            return true;
        }
        /// <summary>
        /// Возвращает список доступных классов в данном модуле.
        /// </summary>
        public override UniXP.Common.CModuleClassInfo GetClassInfo()
        {
            return new CBudgetDocModuleClassInfo();
        }
    }

    public class ModuleInfo : PlugIn.IModuleInfo
    {
        public UniXP.Common.CClientModuleInfo GetModuleInfo()
        {
            return new CBudgetDocModuleInfo();
        }
    }

}
