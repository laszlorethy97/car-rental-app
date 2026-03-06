import { Routes } from '@angular/router';
import { Common } from './common/common';
import { GuestAccess } from './pages/guest-access/guest-access';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Welcome } from './pages/welcome/welcome';
import { Dashboard } from './pages/dashboard/dashboard';
import { GuestForm } from './pages/guest-form/guest-form';

export const routes: Routes = [
    {
        path: '',
        component: Common,
        children: [
            {
                path: '',
                component: Welcome
            },
            {
                path: 'register',
                component: Register
            },
            {
                path: 'login',
                component: Login
            },
            {
                path: 'guest-access',
                component: GuestAccess
            },
            {
                path: 'deshboard',
                component: Dashboard
            },
            {
                path: 'guest-form',
                component: GuestForm
            }    
        ]
    }
];
