import ReactDOM from 'react-dom/client';
import App from './App.tsx';
import './index.css';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { Auth0Provider } from '@auth0/auth0-react';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const httpClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false // disable fetching from server on losing focus.
    }
  }
});

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
]);

const domain: string = `${import.meta.env.VITE_AUTH0_DOMAIN}`;
const clientId: string = `${import.meta.env.VITE_AUTH0_CLIENT_ID}`;

ReactDOM.createRoot(document.getElementById('root')!).render(
  <Auth0Provider 
  domain={domain} cacheLocation='localstorage' useRefreshTokens={true} clientId={clientId} authorizationParams={{
    redirect_uri: `${import.meta.env.VITE_AUTH0_REDIRECT_URI}`,
    audience: "https://mesher.eu.auth0.com/api/v2/",
    scope: "read:current_user update:current_user_metadata"
  }}>
  <QueryClientProvider client={httpClient}>
  <RouterProvider router={router} />
  </QueryClientProvider>
  </Auth0Provider>
)
