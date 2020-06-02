import Vue from 'vue';
import router from './router';
import store from './store';
import Layout from './Layout.vue';
import vuetify from './plugins/vuetify';
import 'roboto-fontface/css/roboto/roboto-fontface.css';
import '@mdi/font/css/materialdesignicons.css';
import VueVideoPlayer from 'vue-video-player';
import 'video.js/dist/video-js.css';
import VueApexCharts from 'vue-apexcharts';

Vue.component('apexchart', VueApexCharts);
Vue.use(VueApexCharts);

Vue.config.productionTip = false;

Vue.use(VueVideoPlayer);

new Vue({
    router,
    store,
    vuetify,
    VueApexCharts,
    render: h => h(Layout)
}).$mount('#app');
