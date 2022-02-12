import Vue from 'vue';
import VueRouter from 'vue-router';
import CreatePlan from '../views/CreatePlan.vue';
import MyPlan from '../views/MyPlan.vue';
import Prijava from '../views/Prijava.vue';
import Registracija from '../views/Registracija.vue';
import StepperPlan from '../views/StepperPlan.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: '/createplan',
        name: CreatePlan,
        component: CreatePlan
    },
    {
        path: '/myplan',
        name: MyPlan,
        component: MyPlan
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
    },
    {
        path: '/StepperPlan',
        name: StepperPlan,
        component: StepperPlan
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
