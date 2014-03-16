using System;
using System.Collections.Generic;
using System.Text;

namespace ErpBudgetBudgetDoc
{
    /// <summary>
    /// Интерфейс для работы с маршрутом бюджетного документа
    /// </summary>
    public interface IBudgetDocRoute
    {
        /// <summary>
        /// Отрисовывает текущий маршрут
        /// </summary>
        /// <param name="objRoutePointList">список точек маршрута</param>
        /// <param name="IsNeedFillUserList">заполнять список пользователей</param>
        void RouteDraw(List<ERP_Budget.Common.CRoutePoint> objRoutePointList, System.Boolean IsNeedFillUserList);
        /// <summary>
        /// Минимизирует размеры элемента управления
        /// </summary>
        void HideControl();
        /// <summary>
        /// очищает маршрут
        /// </summary>
        void ClearRoute();
        /// <summary>
        /// Возвращает список точек маршрута
        /// </summary>
        List<ERP_Budget.Common.CRoutePoint> GetRoutePointList();
        /// <summary>
        /// Делает выбор маршрут на основании списка значений
        /// </summary>
        /// <param name="objInitRouteVariableList">список переменных, влияющих на выбор маршрута документа</param>
        void SelectRoute( List<ERP_Budget.Common.CRouteVariable> objInitRouteVariableList, System.String strDR );
        /// <summary>
        /// Отображает/прячет кнопку оптимизации маршрута
        /// </summary>
        /// <param name="bShow">true - показать; false - спрятать</param>
        void ShowOptimizeBtn(System.Boolean bShow);
        void SetRouteTmplToNull();
    }
}
