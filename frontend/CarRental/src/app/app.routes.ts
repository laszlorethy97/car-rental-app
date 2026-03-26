import { Routes } from '@angular/router';
import { Common } from './common/common';
import { GuestAccess } from './pages/guest-access/guest-access';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Welcome } from './pages/welcome/welcome';
import { Dashboard } from './pages/dashboard/dashboard';
import { GuestForm } from './pages/guest-form/guest-form';
import { GeneralRentalHistory } from './pages/general-rental-history/general-rental-history';
import { GeneralCarList } from './pages/general-car-list/general-car-list';
import { GeneralRentCar } from './pages/general-rent-car/general-rent-car';
import { GeneralEditProfile } from './pages/general-edit-profile/general-edit-profile';
import { AgentRentalhistory } from './pages/agent-rentalhistory/agent-rentalhistory';
import { RentalModify } from './pages/rental-modify/rental-modify';
import { AddInvoice } from './pages/add-invoice/add-invoice';
import { CloseRental } from './pages/close-rental/close-rental';
import { authGuard } from './auth-guard';

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
                component: Dashboard,
                canActivate: [authGuard]
            },
            {
                path: 'guest-form',
                component: GuestForm
            },
            {
                path: 'general-rental-history',
                component: GeneralRentalHistory,
                canActivate: [authGuard]
            },
            {
                path: 'general-car-list',
                component: GeneralCarList,
                canActivate: [authGuard]
            },
            {
                path: 'general-rent-car/:id',
                component: GeneralRentCar,
                canActivate: [authGuard]
            },
            {
                path: 'general-edit-profile',
                component: GeneralEditProfile,
                canActivate: [authGuard]
            },
            {
                path: 'agent-rental-history',
                component: AgentRentalhistory,
                canActivate: [authGuard]
            },
            {
                path: 'add-invoice/:id',
                component: AddInvoice,
                canActivate: [authGuard]
            },
            {
                path: 'invoice-modify/:id',
                component: RentalModify,
                canActivate: [authGuard]
            },
            {
                path: 'close-rental/:id',
                component: CloseRental,
                canActivate: [authGuard]
            }

        ]
    }
];
