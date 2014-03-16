using System;
using System.Collections.Generic;
using System.Text;

namespace ErpBudgetBudgetDoc
{
    /// <summary>
    /// Интерфейс для объекта "Тип бюджетного документа"
    /// </summary>
    public interface IBudgetDocType
    {
        /// <summary>
        /// Обновляет список доступных типов бюджетного документа
        /// </summary>
        /// <param name="objInitBudgetDocTypeVariableList">список переменных, влияющих на выбор типа документа</param>
        void LoadPossibleListTypes( List<ERP_Budget.Common.CBudgetDocTypeVariable> objInitBudgetDocTypeVariableList );
        /// <summary>
        /// Возвращает текущее значение типа бюджетного документа
        /// </summary>
        /// <param name="objBudgetDoctype">тип бюджетного документа</param>
        ERP_Budget.Common.CBudgetDocType GetCurrentType();
        /// <summary>
        /// Принудительно устанавливает текущее значение типа бюджетного документа
        /// </summary>
        /// <param name="objBudgetDoctype">тип бюджетного документа</param>
        void SetCurrentType( ERP_Budget.Common.CBudgetDocType objBudgetDoctype );
        /// <summary>
        /// Отрисовывает список допустимых значений
        /// </summary>
        /// <param name="objBudgetDocType">тип документа, кторый нужно выбрать</param>
        void DrawTypesInComboBox(ERP_Budget.Common.CBudgetDocType objBudgetDocType);
        /// <summary>
        /// Отрисовывает элемент управления
        /// </summary>
        void DrawControl();
        /// <summary>
        /// Принудительно устанавливает первый из списка возможных значений типа бюджетного документа
        /// </summary>
        void SelectFirstDocType();
    }
}
