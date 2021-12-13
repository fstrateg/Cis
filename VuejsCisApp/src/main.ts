import Vue from 'vue';
import App from './App.vue';
import VueRouter from './router'

Vue.config.productionTip = true;


new Vue({
    router: VueRouter,
    render: h => h(App)
}).$mount('#app');
