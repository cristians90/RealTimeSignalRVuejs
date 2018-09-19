import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    countMessages: 0,
    countInfo: 0,
    countSuccess: 0,
    countWarning: 0,
    countError: 0
  },
  getters: {
    countMessages: state => {
      return state.countMessages;
    },
    countInfo: state => {
      return state.countInfo;
    },
    countSuccess: state => {
      return state.countSuccess;
    },
    countWarning: state => {
      return state.countWarning;
    },
    countError: state => {
      return state.countError;
    }
  },
  mutations: {
    incrementCountMessages: state => {
      state.countMessages++;
    },
    incrementCountInfo: state => {
      state.countInfo++;
    },
    incrementCountSuccess: state => {
      state.countSuccess++;
    },
    incrementCountWarning: state => {
      state.countWarning++;
    },
    incrementCountError: state => {
      state.countError++;
    }
  },
  actions: {
    incrementMessages: ({ commit }) => {
      commit("incrementCountMessages");
    },
    incrementInfo: ({ commit }) => {
      commit("incrementCountInfo");
    },
    incrementSuccess: ({ commit }) => {
      commit("incrementCountSuccess");
    },
    incrementWarning: ({ commit }) => {
      commit("incrementCountWarning");
    },
    incrementError: ({ commit }) => {
      commit("incrementCountError");
    }
  }
});
