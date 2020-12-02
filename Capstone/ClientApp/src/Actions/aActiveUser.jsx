const activeUser = (username) => {
  return {
    type: "ACTIVE_USER",
    payload: username,
  };
};

export default activeUser;
