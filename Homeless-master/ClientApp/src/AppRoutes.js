import Homeless from "./components/Homeless";
import HelpPoint from "./components/HelpPoint";
import HomelessMessage from "./components/HomelessMessage";
import ReferenceInfo from "./components/ReferenceInfo";
import Auth from "./components/Auth";
import { Layout } from "./components/Layout";
import AuthRouteContainer from "./components/AuthRouteContainer";
import { NotFoundPageContainer } from "./components/NotFoundPageContainer";


export function AppRoutes(): RouteObject[] {
    const result: RouteObject[] = [
        {
            element: <Layout />,
            children: [
                { path: "/authenticate", element: <Auth /> },
                {
                    element: <AuthRouteContainer />,
                    children: [
                        { path: "/homeless", element: <Homeless /> },
                        { path: '/helppoint', element: <HelpPoint /> },
                        { path: '/report', element: <null /> },
                        { path: '/homelessmessage', element: <HomelessMessage /> },
                        { path: '/referenceinfo', element: <ReferenceInfo /> },
                        { path: '/', element: <Homeless /> }
                    ],
                }
               
            ],
        },
        {
             path: "*", element: <NotFoundPageContainer /> 
        }
    ];
    return result;
}
