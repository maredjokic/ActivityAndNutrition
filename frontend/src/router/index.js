import Vue from 'vue';
import VueRouter from 'vue-router';
import Pocetna from '../views/Pocetna.vue';
import Pregled from '../views/Pregled.vue';
import Trcanje from '../views/Trcanje.vue';
import PlanTrcanja from '../views/PlanTrcanja.vue';
import Prijava from '../views/Prijava.vue';
import Registracija from '../views/Registracija.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        name: 'Pocetna',
        component: Pocetna
    },
    {
        path: '/Pregled',
        name: Pregled,
        component: Pregled
    },
    {
        path: '/Trcanje',
        name: 'Trcanje',
        component: Trcanje

    },
    {
        path: '/PlanTrcanja',
        name: PlanTrcanja,
        component: PlanTrcanja
    },
    {
        path: '/Prijava',
        name: 'Prijava',
        component: Prijava
    },
    {
        path: '/Registracija',
        name: Registracija,
        component: Registracija
    }
//   {
//     path: '/about',
//     name: 'About',
//     // route level code-splitting
//     // this generates a separate chunk (about.[hash].js) for this route
//     // which is lazy-loaded when the route is visited.
//     component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
//   }
];

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});

export default router;
