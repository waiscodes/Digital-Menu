import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";

const Menu = () => {
  const { username } = useParams();
  const [menuItems, setMenuItems] = useState([]);
  const [loading, setLoading] = useState(true);

  const renderMenuItems = (menuItems) => {
    return (
      <>
        {menuItems.map((item) => {
          return <pre>{JSON.stringify(item, null, 2)}</pre>;
        })}
      </>
    );
  };

  const populateMenuItems = async () => {
    const response = await axios({
      method: "get",
      url: "Values/ListMenu",
      params: {
        username: username,
      },
    });
    setMenuItems(response.data);
    setLoading(false);
  };

  useEffect(() => {
    populateMenuItems();
  }, [loading]);

  let content = loading ? <p>Loading...</p> : renderMenuItems(menuItems);

  return <>{content}</>;
};

export default Menu;
