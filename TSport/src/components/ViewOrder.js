import "./Admin.css";
import Sidebar from "./Sidebar";
import Navbar from "./Navbar";
import { Row, Table } from "react-bootstrap";
import { Button, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, IconButton, InputLabel, MenuItem, Pagination, Paper, Select, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, styled } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { useState } from "react";

const ViewOrder = () => {
  const [openDialog, setOpenDialog] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [openConfirmationDialog, setOpenConfirmationDialog] = useState(false);
  const [openDetailDialog, setOpenDetailDialog] = useState(false);
  const [mess, setMess] = useState("");
  const [page, setPage] = useState(1);

  const handleOpenDialog = (user) => {
    setOpenDialog(true);
    setIsEdit(true);
  };

  const handleOpenConfirmationDialog = (id) => {
    setOpenConfirmationDialog(true);
  };

  const handleOnCloseConfirmationDialog = () => {
    setOpenConfirmationDialog(false);
    setOpenDialog(false);
    setMess("");
    setIsEdit(false);
  };

  const handleDeleteUser = async () => {
    //success
    setMess(`Xóa thành công !!!!`);
    handleOnCloseConfirmationDialog();
    setOpenConfirmationDialog(true);
    //fail
    setMess(`Không xóa được !!!!`);
    handleOnCloseConfirmationDialog();
    setOpenConfirmationDialog(true);
  };

  const handleEditUser = async () => {
    //success
      setOpenConfirmationDialog(true);
      setMess("Cập nhật thành công !!!!");
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
                <h2 style={{textAlign: "left", paddingLeft: "1rem"}}>Đơn hàng</h2>
            </div>
            <div class="card-body">
            <StyledTableContainer component={Paper}>
              <StyledTable aria-label="User table">
                <StyledTableHead>
                  <TableRow>
                    <StyledTableCell align="center">ID</StyledTableCell>
                    <StyledTableCell align="center">Tên khách hàng</StyledTableCell>
                    <StyledTableCell align="center">Tổng tiền</StyledTableCell>
                    <StyledTableCell align="center">Trạng thái</StyledTableCell>
                    <StyledTableCell align="center"></StyledTableCell>
                  </TableRow>
                </StyledTableHead>
                <TableBody>
                  <TableRow>
                      <StyledTableCell align="center" onClick={() => {setOpenDetailDialog(true)}}>
                      1
                      </StyledTableCell>
                      <StyledTableCell align="center">
                      John
                      </StyledTableCell>
                      <StyledTableCell align="center">
                      150.000đ
                      </StyledTableCell>
                      <StyledTableCell align="center">
                      <IconButton style={{color: "#fff", width: "30%", backgroundColor: "#ff9a3c", borderRadius: "5px"}}>
                        Đang giao
                      </IconButton>
                      </StyledTableCell>
                      <StyledTableCell align="center" style={{padding: "0", display: "flex", alignItems: "center",flexDirection: "column"}}>
                      <IconButton
                          aria-label="delete"
                          className="btn btn-edit"
                          onClick={() => handleOpenConfirmationDialog()}
                          style={{color: "#fff"}}
                        >
                          Đã giao
                        </IconButton>
                      <IconButton aria-label="edit" className="btn btn-delete" onClick={() => handleOpenConfirmationDialog()} style={{color: "#fff"}}>
                          Hủy
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
              <Button onClick={handleDeleteUser} color="primary">
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
        <DialogTitle>Chi tiết người dùng</DialogTitle>
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

export default ViewOrder;

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