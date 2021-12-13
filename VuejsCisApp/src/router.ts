import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import BypassVue from './components/Bypass.vue'
import Login from './components/Login.vue'
import Archive from './components/Archive.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
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
]

export default new VueRouter(
    {
        mode: 'history',
        base: process.env.BASE_URL,
        routes: routes
    })