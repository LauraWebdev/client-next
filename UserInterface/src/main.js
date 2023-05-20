import { createApp } from 'vue';
import App from './App.vue';
import Router from "@/router";

import './assets/reset.scss';
import './assets/app.scss';
import '@mdi/font/scss/materialdesignicons.scss';

import FloatingVue from 'floating-vue';
import 'floating-vue/dist/style.css';

import mitt from 'mitt';

const app = createApp(App);

app.config.globalProperties.window = window;
app.provide('emitter', new mitt());
app.use(FloatingVue);
app.use(Router);

import SpinButton from "@/components/Common/SpinButton.vue";
import SpinLoader from "@/components/Common/SpinLoader.vue";
import SpinSwitch from "@/components/Common/SpinSwitch.vue";
import SpinTabBar from "@/components/Common/SpinTabBar.vue";
import SpinTabItem from "@/components/Common/SpinTabItem.vue";

app.component('SpinButton', SpinButton);
app.component('SpinLoader', SpinLoader);
app.component('SpinSwitch', SpinSwitch);
app.component('SpinTabBar', SpinTabBar);
app.component('SpinTabItem', SpinTabItem);

app.mount('#app');