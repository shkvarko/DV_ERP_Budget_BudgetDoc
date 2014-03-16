using System;
using System.Collections.Generic;
using System.Text;

namespace ErpBudgetBudgetDoc
{
    public interface IBudgetDoc
    {
        /// <summary>
        /// Отрисовывает элемент управления
        /// </summary>
        void DrawControl();
        /// <summary>
        /// Устанавливает фокус
        /// </summary>
        void SetFocus();
        /// <summary>
        /// Открывает документ
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        System.Boolean bOpenBudgetDoc();
        /// <summary>
        /// Копирует бюджетный документ
        /// </summary>
        /// <param name="objBudgetDoc">исходный документ</param>
        /// <returns>true- удачное завершение;false - ошибка</returns>
        System.Boolean CopyBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc);
        /// <summary>
        /// Распределяет сумму документа по подстатьям
        /// </summary>
        /// <returns>true- удачное завершение;false - ошибка</returns>
        System.Boolean ReorganizeDocSum();
        System.Boolean GetOpenDocFlag();
        /// <summary>
        /// Подтвержает сумму расхода, указанную в редакторе
        /// </summary>
        /// <returns>true- удачное завершение;false - ошибка</returns>
        System.Boolean ConfirmBudgetDocMoney();
        event EventHandler<ChangeRouteVariableEventArgs> ChangeRouteVariable;
        event EventHandler<ChangeDocTypeVariableEventArgs> ChangeDocTypeVariable;
        event EventHandler<ChangeBudgetDocPropertieEventArgs> ChangeBudgetDocPropertie;
        /// <summary>
        /// Фильтрует список доступных статей для выбранного типа документа
        /// </summary>
        void RefreshDebitArticleListForNewBudgetDocType();
    }
}
