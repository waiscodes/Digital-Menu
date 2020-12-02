const aActiveUser = (username) => {
  return {
    type: "ACTIVE_USER",
    username,
  };
};

export default aActiveUser;
