import Vue from 'vue'
import App from './App.vue'
import VueResource from 'vue-resource'
import router from './router'
import VueToast from 'vue-toast-notification';
import 'vue-toast-notification/dist/theme-sugar.css';

Vue.config.productionTip = false;
Vue.use(VueResource);
Vue.use(VueToast);




new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
