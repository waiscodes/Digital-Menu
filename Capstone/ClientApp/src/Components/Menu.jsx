import React, { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import axios from "axios";

const Menu = () => {
  const { username } = useParams();
  const [menuItems, setMenuItems] = useState([]);
  const [loading, setLoading] = useState(true);

  const renderMenuItems = (menuItems) => {
    return (
      <>
        {menuItems.map((item) => {
          return (
            <>
              <Link to={"/Details/" + item.id}>
                <div className='menu-card' id={item.id}>
                  {item.imageName}
                  {item.name}
                  {item.price}
                  {item.ingredients}
                </div>
              </Link>
            </>
          );
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
