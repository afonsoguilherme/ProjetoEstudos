import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueResoruse from 'vue-resource'

Vue.config.productionTip = false
Vue.use(VueResoruse);

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')