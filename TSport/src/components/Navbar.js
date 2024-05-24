import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { styled, TextField } from "@mui/material";
import { Image } from "react-bootstrap";
import LogoutIcon from '@mui/icons-material/Logout';
import "./Navbar.css";

const Navbar = () => {
    const [search, setSearch] = useState("");
    const navigate = useNavigate();
    const location = useLocation();
    const [page, setPage] = useState("");

    useEffect(() => {
      if (location.state !== null) {
        setPage(location.state);
      }
    }, [location.state]);
    return (
        <div className="navbar">
      <div className="container-fluid">
        <div className="breadcrumb">
          <span style={{fontSize: "20px"}}>Quản lý/</span>
          <h1 style={{fontWeight: "bolder", marginTop: "0"}}>{page === "viewOrder" ? "Xem đơn hàng" : page === "product" ? "Quản lý áo đấu" : page === "user" ? "Quản lý người dùng" : "Thống kê"}</h1>
        </div>
        <div className="navbar-collapse">
          <FlexContainer>
                      <DialogTextField
                        label="Tìm kiếm ..."
                        value={search}
                        onChange={(e) => setSearch(e.target.value)}
                      />
                    </FlexContainer>
          <ul className="navbar-nav-right">
            <li>
            <div className="navbar-profile">
                <div className="navbar-profile" style={{marginRight: "0"}}>
                        <Image className="img-xs rounded-circle" src="" style={{width:"40px",height:"40px", borderRadius:"50%"}} alt=""/>
                    </div>
                  <span>Chào, <strong>userName</strong></span>
                </div>
                <ul className="drop-down">
                <li>
                  <h4>Hồ sơ</h4>
                </li>
                <li>
                <p
                      style={{ cursor: "pointer" }}
                      onClick={() => navigate("/myprofile")}
                    >
                      Hồ sơ của tôi
                    </p>
                </li>
                <li>
                <p
                      style={{ cursor: "pointer", display: "flex", alignItems: "center"}}
                    >
                    <LogoutIcon/>
                      Đăng xuất
                    </p>
                </li>
              </ul>
            </li>
          </ul>
        </div>
      </div>
    </div>
    )
}

const FlexContainer = styled("div")({
    display: "flex",
    alignItems: "center",
  });

  const DialogTextField = styled(TextField)({
    width: "100%",
  });

export default Navbar;