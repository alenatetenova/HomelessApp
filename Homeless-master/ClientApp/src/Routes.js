
import { useRoutes } from "react-router-dom";
import { AppRoutes } from "./AppRoutes";


export function Routes() {
    const result = useRoutes(AppRoutes());
    return result;
}

/*
const AppRoutes = [
    {
        path: '/authenticate',
        element: < Auth />
    },

  {
    path: '/homeless',
    element: <Homeless />
  },
  {
    path: '/helppoint',
    element: <HelpPoint />
  },
  {
      path: '/homelessmessage',
      element: <HomelessMessage />
    },
    {
        path: '/referenceinfo',
        element: <ReferenceInfo />
    },
    {
        path: '/report',
        element: < null />
    }
    
];
*/
