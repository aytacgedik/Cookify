const initialState = {
    isLoggedIn: false
}

function loginReducer(state = initialState, action)
{
    var newIsLoggedIn = false;
    switch (action.type) {
        case "LOG_IN": {
            newIsLoggedIn = true;
            break;
        }
        case "LOG_OUT": {
            newIsLoggedIn = false;
            break;
        }
    }
    return {
        ...state,
        isLoggedIn: newIsLoggedIn
    }
}
export default loginReducer