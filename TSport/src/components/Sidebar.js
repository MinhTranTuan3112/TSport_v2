import "./Sidebar.css";
import PieChartIcon from '@mui/icons-material/PieChart';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import DryCleaningIcon from '@mui/icons-material/DryCleaning';
import GroupIcon from '@mui/icons-material/Group';
import { useLocation, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";

const Sidebar = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [page, setPage] = useState("");

  useEffect(() => {
    if (location.state !== null) {
      setPage(location.state);
    }
  }, [location.state]);
    return(
      <div className="sidenav">
      <div className="sidenav-header">
          <span className="ms-1 font-weight-bold text-white">Logo</span>
      </div>
      <hr className="horizontal light mt-0 mb-2"/>
      <div>
        <ul className="navbar-nav">
        <li className={`nav-item ${page === "admin" ? "active1" : page === "" ? "active1" : ""}`} style={{cursor: "pointer", justifyContent: "left"}} onClick={() => navigate("/admin", {state: "admin"})}>
              <span className="menu-icon">
              <PieChartIcon/>
              </span>
              <span className="menu-title">Thống kê</span>
          </li>
          <li className={`nav-item ${page === "viewOrder" ? "active1" : ""}`} style={{cursor: "pointer"}} onClick={() => navigate("/order", {state: "viewOrder"})}>
              <span className="menu-icon">
                <ShoppingCartIcon/>
              </span>
              <span className="menu-title">Đơn hàng</span>
          </li>
          <li className={`nav-item ${page === "product" ? "active1" : ""}`} style={{cursor: "pointer"}} onClick={() => navigate("/product", {state: "product"})}>
              <span className="menu-icon">
                <DryCleaningIcon/>
              </span>
              <span className="menu-title">Quản lý áo đấu</span>
          </li>
          <li className={`nav-item ${page === "user" ? "active1" : ""}`} style={{cursor: "pointer"}} onClick={() => navigate("/user", {state: "user"})}>
              <span className="menu-icon">
                <GroupIcon/>
              </span>
              <span className="menu-title">Quản lý người dùng</span>
          </li>
        </ul>
      </div>
    </div>
    );
}

export default Sidebar;