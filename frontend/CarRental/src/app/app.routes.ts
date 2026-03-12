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
            },
            {
                path: 'general-rental-history',
                component: GeneralRentalHistory
            },
            {
                path: 'general-car-list',
                component: GeneralCarList
            },
            {
                path: 'general-rent-car',
                component: GeneralRentCar
            },
            {
                path: 'general-edit-profile',
                component: GeneralEditProfile
            }
        ]
    }
];
