const activeUser = (state, action) => {
  switch (action.type) {
    case "ACTIVE_USER":
      return { ...state, username: action.username };
  }
};
