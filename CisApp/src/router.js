import Vue from 'vue';
import VueRouter from 'vue-router';
import { isLoggedIn } from './libs/auth';
import BypassVue from './components/Bypass.vue';
import Login from './components/Login.vue';
import Archive from './components/Archive.vue';
import BypassEdit from './views/BypassEdit.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        name: 'BypassVue',
        meta: {
            allowGuest: false
        },
        component: BypassVue
    },
    {
        path: '/login',
        name: 'Login',
        meta: {
            allowGuest: true
        },
        component: Login
    },
    {
        path: '/archive',
        name: 'Archive',
        meta: {
            allowGuest: false
        },
        component: Archive
    },
    {
        path: '/bypassedit',
        name: 'BypassEdit',
        meta: {
            allowGuest: false
        },
        component: BypassEdit
    },

];

const Router = new VueRouter(
    {
        mode: 'history',
        base: process.env.BASE_URL,
        routes: routes
    });

Router.beforeEach((to, from, next) => {
    if (!to.meta.allowGuest && !isLoggedIn()) {
        next({path:'/login'});
    }
    next();
});

export default Router;