import * as m from '../mutation_types';
import * as a from '../action_types';
import * as a from '../action_types';

// initial state
const state = {
    user: undefined,
    loggingInOrOut: false,
    sessionExpired: false
};

const getters = {
    user: state => state.user,
    loggedIn: state => state.user !== undefined,
    sessionExpired: state => state.sessionExpired
};

const mutations = {
    [m.USERS_AUTH_REQUEST] (state) {
        state.loggingInOrOut = true;
    },
    [m.USERS_AUTH_SUCCESS] (state, data) {
        state.loggingInOrOut = false;
        let username;
        if (data) {
            username = data;
        }
        state.user = username;
        state.sessionExpired = false;
    },
    [m.USERS_CLEAR_DATA] (state) {
        state.user = undefined; 
        state.loggingInOrOut = false;
    },
    [m.SESSION_EXPIRED] (state, expired) {
        state.sessionExpired = expired;
    }
};