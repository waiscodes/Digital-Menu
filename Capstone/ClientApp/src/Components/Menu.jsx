import React, { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import axios from "axios";

const Menu = () => {
  const { username } = useParams();
  const [menuItems, setMenuItems] = useState([]);
  const [loading, setLoading] = useState(true);
  const [path, setPath] = useState();

  const renderMenuItems = (path, menuItems) => {
    return (
      <>
        {menuItems.map((item) => {
          return (
            <>
              <Link to={"/Details/" + item.id}>
                <div className='menu-card' id={item.id}>
                  <img src={path + item.imageName} />
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
    await axios({
      method: "get",
      url: "Values/ImagePath",
    }).then((response) => {
      setPath(response.data);
    });

    await axios({
      method: "get",
      url: "Values/ListMenu",
      params: {
        username: username,
      },
    }).then((response) => {
      setMenuItems(response.data);
      setLoading(false);
    });
  };

  useEffect(() => {
    populateMenuItems();
  }, [loading]);

  let content = loading ? <p>Loading...</p> : renderMenuItems(path, menuItems);

  return <>{content}</>;
};

export default Menu;
