import "./Admin.css";
import Sidebar from "./Sidebar";
import Navbar from "./Navbar";
import { Col, Row, Table } from "react-bootstrap";
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, IconButton, InputLabel, MenuItem, Pagination, Paper, Select, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, styled } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import AddIcon from '@mui/icons-material/Add';
import AddPhotoAlternateIcon from "@mui/icons-material/AddPhotoAlternate";
import { useState } from "react";

const ManageProduct = () => {
  const [id, setId] = useState("");
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [gender, setGender] = useState("");
  const [address, setAddress] = useState("");
  const [phone, setPhone] = useState("");
  const [dob, setDob] = useState("");
  const [role, setRole] = useState("");
  const [openDialog, setOpenDialog] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [openConfirmationDialog, setOpenConfirmationDialog] = useState(false);
  const [openDetailDialog, setOpenDetailDialog] = useState(false);
  const [selectedUser, setSelectedUser] = useState({});
  const [mess, setMess] = useState("");
  const [page, setPage] = useState(1);

  const handleOpenDialog = (user) => {
    setOpenDialog(true);
    // setId(user.id);
    // setName(user.name);
    // setEmail(user.email);
    // setGender(user.gender);
    // setAddress(user.address);
    // setPhone(user.phone);
    // setDob(user.dob);
    // setRole(user.role);
    setIsEdit(true);
  };

  const handleOpenConfirmationDialog = (id) => {
    setOpenConfirmationDialog(true);
    //setId(id);
  };

  const handleOnCloseConfirmationDialog = () => {
    setOpenConfirmationDialog(false);
    setOpenDialog(false);
    setId("");
    setName("");
    setEmail("");
    setGender("");
    setAddress("");
    setPhone("");
    setDob("");
    setRole("");
    setMess("");
    setIsEdit(false);
  };

  const handleDeleteProduct = async () => {
    //success
    setMess(`Xóa thành công !!!!`);
    handleOnCloseConfirmationDialog();
    setOpenConfirmationDialog(true);
    //fail
    setMess(`Không xóa được !!!!`);
    handleOnCloseConfirmationDialog();
    setOpenConfirmationDialog(true);
  };

  const handleEditProduct = async () => {
    //success
      setOpenConfirmationDialog(true);
      setMess("Cập nhật thành công !!!!");
    //fail
    setOpenConfirmationDialog(true);
    setMess("Thất bại !!!!");
  }

  const handleAddProduct = async () => {
    //success
    setOpenConfirmationDialog(true);
    setMess("Thêm mới thành công!!!!");
  //fail
  setOpenConfirmationDialog(true);
  setMess("Thất bại !!!!");
  }

    return (
        <div className="container-scroller">
          <div style={{width: "15%"}}>
          <Sidebar />
          </div>
        <div style={{width: "85%", paddingRight: "20px"}}>
          <Row>
            <Navbar />
          </Row>
          <Row style={{marginTop: "40px"}}>
          <div class="card">
            <div class="card-header-chart">
                <h2 style={{textAlign: "left", paddingLeft: "1rem"}}>Quản lý áo đấu</h2>
            </div>
            <div class="card-body">
            <FlexContainer style={{width: "100%", display: "flex", justifyContent: "right"}}>
                <Button className="btn btn-add" style={{width: "150px", color: "#fff"}} onClick={() => setOpenDialog(true)}>
                  <AddIcon/>
                  Thêm mẫu
                </Button>
              </FlexContainer>

            <StyledTableContainer component={Paper}>
              <StyledTable aria-label="User table">
                <StyledTableHead>
                  <TableRow>
                    <StyledTableCell align="center">ID</StyledTableCell>
                    <StyledTableCell align="center">Code</StyledTableCell>
                    <StyledTableCell align="center">Câu lạc bộ</StyledTableCell>
                    <StyledTableCell align="center">Mùa giải</StyledTableCell>
                    <StyledTableCell align="center"></StyledTableCell>
                  </TableRow>
                </StyledTableHead>
                <TableBody>
                  <TableRow>
                      <StyledTableCell align="center" onClick={() => {setOpenDetailDialog(true);setSelectedUser()}}>
                      1
                      </StyledTableCell>
                      <StyledTableCell align="center">
                      SGV23
                      </StyledTableCell>
                      <StyledTableCell align="center">
                      Sài Gòn Phantom
                      </StyledTableCell>
                      <StyledTableCell align="center">
                      V-League 2023
                      </StyledTableCell>
                      <StyledTableCell align="center" style={{padding: "0"}}>
                      <IconButton aria-label="edit" className="btn btn-edit" onClick={() => handleOpenDialog()} style={{color: "#fff"}}>
                          <EditIcon/>
                        </IconButton>
                         <IconButton
                          aria-label="delete"
                          className="btn btn-delete"
                          onClick={() => handleOpenConfirmationDialog()}
                          style={{color: "#fff"}}
                        >
                          <DeleteIcon/>
                        </IconButton>
                      </StyledTableCell>
                    </TableRow>
                </TableBody>
              </StyledTable>
            </StyledTableContainer>
            </div>
            <div className="card-footer">
            <FlexContainer>
                <Pagination
                  count={Math.ceil(17 / 7)}
                  page={page}
                  onChange={(e, newPage) => setPage(newPage)}
                />
              </FlexContainer>
            </div>
          </div>
          </Row>

          {openDialog && (
        <StyledDialog open={openDialog} onClose={() => setOpenDialog(false)}>
      <DialogTitle>{isEdit ? "Chỉnh sửa" : "Thêm mới"} mẫu áo</DialogTitle>
<DialogContent>
        <Row style={{display: "flex"}}>
            <div style={{width: "30%"}}>
                <div style={{ border: "2px dashed #000000", width: "90%"}}>
                    <input id="upload-image" style={{backgroundColor: "#4a785f", borderColor: "unset", width: "15%", alignItems: "center"}} type="file" multiple hidden accept="image/*"/>
                    <label for="upload-image" style={{ width: "100%", height: "auto" }}>
                        <AddPhotoAlternateIcon style={{marginLeft: "30%", width: "40%", height: "auto"}} />
                        <h3 style={{textAlign: "center"}}>Click to select</h3>
                    </label>
                </div>
            </div>
            <div style={{width: "70%"}}>
            <DialogTextField
          label="ID"
          // value={id}
        />
        <DialogTextField
          label="Tên"
          //value={name}
          //onChange={(e) => setName(e.target.value)}
        />
        <DialogTextField
          label="Email"
          //value={email}
          //onChange={(e) => setEmail(e.target.value)}
        />
        <DialogTextField
          label="Địa chỉ"
          // value={address}
          // onChange={(e) => setAddress(e.target.value)}
        />
        <DialogTextField
          label="SĐT"
          // value={phone}
          // onChange={(e) => setPhone(e.target.value)}
        />
        <DialogTextField
          label="Ngày sinh"
          type="date"
          // value={dob}
          // onChange={(e) => setDob(e.target.value)}
        />
        <SelectOutlined variant="outlined">
        <InputLabel>Giới tính</InputLabel>
              <Select
                label="Giới tính"
                //value={gender}
                //onChange={(e) => setGender(e.target.value)}
              >
                <MenuItem value="Nam">Nam</MenuItem>
                <MenuItem value="Nữ">Nữ</MenuItem>
              </Select>
            </SelectOutlined>
        <SelectOutlined variant="outlined">
            <InputLabel>Vai trò</InputLabel>
              <Select
                label="Vai trò"
                // value={role}
                // onChange={(e) => setRole(e.target.value)}
              >
                <MenuItem value="Quản trị viên">Quản trị viên</MenuItem>
                <MenuItem value="Quản lý">Quản lý</MenuItem>
                <MenuItem value="Khách hàng">Khách hàng</MenuItem>
              </Select>
            </SelectOutlined>
            </div>
        </Row>
      </DialogContent>

      <DialogActions>
        <Button onClick={handleOnCloseConfirmationDialog}>Thoát</Button>
        <Button onClick={isEdit? handleEditProduct : handleAddProduct} color="primary">
          {isEdit ? "Chỉnh sửa" : "Thêm"}
        </Button>
      </DialogActions>
    </StyledDialog>
      )}


      {openConfirmationDialog && (
        <StyledDialog
          open={openConfirmationDialog}
          onClose={handleOnCloseConfirmationDialog}
          style={{paddingLeft: "35%",paddingRight:"35%"}}
        >
          <DialogTitle>
            {mess === "" ? "Xóa người dùng" : "Thông báo"}
          </DialogTitle>
          <DialogContent>
            {mess === "" ? "Xóa người dùng này?" : mess}
          </DialogContent>
          <DialogActions>
            <Button onClick={handleOnCloseConfirmationDialog} color="primary">
              {mess === "" ? "Thoát" : "OK"}
            </Button>
            {mess === "" && (
              <Button onClick={handleDeleteProduct} color="primary">
                Xóa
              </Button>
            )}
          </DialogActions>
        </StyledDialog>
      )}

      {openDetailDialog && (
        <StyledDialog
          style={{ paddingLeft: "25%", paddingRight: "25%" }}
          open={openDetailDialog}
          onClose={() => openDetailDialog(false)}
        >
        <DialogTitle>Chi tiết mẫu áo</DialogTitle>
        <DialogContent>
        <DialogTextField
          label="ID"
          //value={selectedUser.id}
          disabled
        />
        <DialogTextField
          label="Tên khách hàng"
          //value={selectedUser.name}
          disabled
        />
        <DialogTextField
          label="Email"
          //value={selectedUser.email}
          disabled
        />
        <DialogTextField
          label="Giới tính"
          //value={selectedUser.gender}
          disabled
        />
        <DialogTextField
          label="Địa chỉ"
          //value={selectedUser.address}
          disabled
        />
        <DialogTextField
          label="SĐT"
          //value={selectedUser.phone}
          disabled
        />
        <DialogTextField
          label="Ngày sinh"
          //value={selectedUser.dob}
          disabled
        />
        <DialogTextField
          label="Vai trò"
          //value={selectedUser.role}
          disabled
        />
      </DialogContent>
          <DialogActions>
            <Button onClick={() => setOpenDetailDialog(false)}>Thoát</Button>
          </DialogActions>
        </StyledDialog>
      )}
        </div>
    </div>
    )
}

export default ManageProduct;

const StyledTableContainer = styled(TableContainer)`
  margin-top: 16px;
`;

const StyledTable = styled(Table)`
  min-width: 650px;
  width: 100%;
`;

const StyledTableHead = styled(TableHead)`
  & th {
    position: relative;
    text-align: center;
    font-weight: bold;
  }

  & th::before {
    content: "";
    position: absolute;
    top: 50%;
    left: 0;
    transform: translateY(-50%);
    background-color: rgba(224, 224, 224, 1);
    width: 1px;
    height: 70%;
  }
  background-color: #f5f5f5;
`;

const StyledTableCell = styled(TableCell)`
  font-weight: 300;
  text-align: center;
`;

const StyledDialog = styled(Dialog)(({ theme }) => ({
  "& .MuiPaper-root": {
    width: "100%",
    maxWidth: "1000px",
  },
  "& .MuiDialogTitle-root": {
    fontWeight: "bold",
    fontSize: "1.5rem",
    textShadow: "none",
  },
  "& .MuiTextField-root": {
    marginBottom: theme.spacing(2),
  },
  "& .MuiDialogContent-root": {
    paddingTop: "1rem",
  },
  "& .MuiFormControl-root": {
marginBottom: theme.spacing(2),
  },
  "& .MuiTypography-root": {
    color: "black",
    marginBottom: theme.spacing(2),
  },
  "& .MuiButton-root:not(:last-child)": {
    marginRight: theme.spacing(1),
  },
}));

const DialogTextField = styled(TextField)({
    width: "100%",
  });

  const SelectOutlined = styled(FormControl)({
    width: "40%",
    marginBottom: "10px",
  });

  const FlexContainer = styled("div")({
    display: "flex",
    alignItems: "center",
  });