using System;
using System.Collections.Generic;
using System.Text;

namespace ErpBudgetBudgetDoc
{
    public interface IBudgetDocEvent
    {
        /// <summary>
        /// Очищает список возможных действий
        /// </summary>
        void ClearEventList();
        /// <summary>
        /// Построение списка возможных действий
        /// </summary>
        /// <param name="objRoutePointList">список точек маршрута</param>
        /// <param name="objCurrentUser">пользователь, рпботающий в данный момент с документом</param>
        /// <param name="objDocState">состояние документа</param>
        /// <param name="objProfile">профайл</param>
        void CreateEventList( List<ERP_Budget.Common.CRoutePoint> objRoutePointList,
            ERP_Budget.Common.CUser objCurrentUser, ERP_Budget.Common.CBudgetDocState objDocState,
            UniXP.Common.CProfile objProfile, ERP_Budget.Common.CBudgetDoc objBudgetDoc );
        /// <summary>
        /// Возвращает выбранное действие
        /// </summary>
        /// <returns>выбранное действие</returns>
        ERP_Budget.Common.CBudgetDocEvent GetSelectedEvent();
        /// <summary>
        /// Возвращает доступное количество действий над бюджетным документом
        /// </summary>
        /// <returns>доступное количество действий над бюджетным документом</returns>
        System.Int32 GetEventCount();
        /// <summary>
        /// Минимизирует размеры элемента управления
        /// </summary>
        void HideControl();

    }
}
