import Vue from "vue";
import App from "./App.vue";
import store from "./store";
import VueIziToast from "vue-izitoast";
import Vuetify from "vuetify";

import "material-design-icons-iconfont/dist/material-design-icons.css";
import "izitoast/dist/css/iziToast.min.css";
import "vuetify/dist/vuetify.min.css";

Vue.config.productionTip = false;

Vue.use(Vuetify);
Vue.use(VueIziToast);

new Vue({
  store,
  render: h => h(App)
}).$mount("#app");
