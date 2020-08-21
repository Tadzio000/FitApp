
let id = 0
let defaultDelay = 50000

const alertConstants = {
    SUCCESS: 'ALERT_SUCCESS',
    WARN: 'ALERT_WARN',
    ERROR: 'ALERT_ERROR',
    INFO: 'ALERT_INFO',
    CLEAR: 'ALERT_CLEAR'
  }
  

export const alertActions = {
    success,
    warn,
    error,
    clear,
    info,
}

function success(msg, delay = defaultDelay) {
    return {
        type: alertConstants.SUCCESS,
        payload: {
            type: 'success',
            message: msg,
            delay: delay,
            id: id++
        }
    }
}

function warn(msg, delay = defaultDelay) {
    return {
        type: alertConstants.WARN,
        payload: {
            type: 'warning',
            message: msg,
            delay: delay,
            id: id++
        }
    }
}

function error(msg, delay = defaultDelay) {
    return {
        type: alertConstants.ERROR,
        payload: {
            type: 'danger',
            message: msg,
            delay: delay,
            id: id++
        }
    }
}

function info(msg, delay = defaultDelay) {
    return {
        type: alertConstants.INFO,
        payload: {
            type: 'info',
            message: msg,
            delay: delay,
            id: id++
        }
    }
}

function clear(index) {
    return {
        type: alertConstants.CLEAR,
        payload: {
            index: index
        }
    }
}
