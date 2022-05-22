import Admin from "./pages/Admin";
import {
    ADMIN_ROUTE,
    BASKET_ROUTE,
    DISK_ROUTE,
    LOGIN_ROUTE,
    REGISTRATION_ROUTE,
    SHOP_ROUTE,
    USER_ROUTE
} from "./utils/consts";
import Basket from "./pages/Basket";
import Shop from "./pages/Shop";
import Auth from "./pages/Auth";
import DiskPage from "./pages/DiskPage";
import UserPanel from "./pages/UserPanel";

export const authRoutes = [
    {
        path: ADMIN_ROUTE,
        Component: Admin
    },
    {
        path: BASKET_ROUTE,
        Component: Basket
    },
    {
        path: USER_ROUTE,
        Component: UserPanel
    }
]

export const publicRoutes = [
    {
        path: SHOP_ROUTE,
        Component: Shop
    },
    {
        path: LOGIN_ROUTE,
        Component:Auth
    },
    {
        path: REGISTRATION_ROUTE,
        Component: Auth
    },
    {
        path: DISK_ROUTE + '/:id',
        Component: DiskPage
    },
]