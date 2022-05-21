import Vue from 'vue';
import VueRouter from 'vue-router';
import BypassVue from './components/Bypass.vue';
import Login from './components/Login.vue';
import Archive from './components/Archive.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        name: 'BypassVue',
        component: BypassVue
    },
    {
        path: '/login',
        name: 'Login',
        component: Login
    },
    {
        path: '/archive',
        name: 'Archive',
        component: Archive
    },

];

const Router = new VueRouter(
    {
        mode: 'history',
        base: process.env.BASE_URL,
        routes: routes
    });
export default Router;