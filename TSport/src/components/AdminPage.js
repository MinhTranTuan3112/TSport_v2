import "./Admin.css";
import { Card, CardFooter, CardHeader, Row } from "react-bootstrap";
import Sidebar from "./Sidebar";
import Navbar from "./Navbar";
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import { LineChart, Line, CartesianGrid, XAxis, YAxis, Tooltip, BarChart, Bar } from 'recharts';

const AdminPage = () => {
  const data1 = [
    { name: 'Jan', uv: 4000, pv: 2400, amt: 2400 },
    { name: 'Feb', uv: 3000, pv: 1398, amt: 2210 },
    { name: 'Mar', uv: 2000, pv: 9800, amt: 2290 },
    { name: 'Apr', uv: 2780, pv: 3908, amt: 2000 },
    { name: 'May', uv: 1890, pv: 4800, amt: 2181 },
    { name: 'Jun', uv: 2390, pv: 3800, amt: 2500 },
    { name: 'Jul', uv: 3490, pv: 4300, amt: 2100 },
  ];

    return (
        <div className="container-scroller">
          <div style={{width: "15%"}}>
          <Sidebar />
          </div>
        <div style={{width: "85%", paddingRight: "20px"}}>
          <Row>
            <Navbar />
          </Row>
          <Row style={{display: "flex", marginTop: "40px"}}>
          <div style={{width: "25%", padding: "0 10px"}}>
          <Card className="card">
            <CardHeader className="card-header">
              <div className="icon">
                
              </div>
              <div className="text-end">
                <p className="text-sm">Doanh thu hôm nay</p>
                <h3 >53đ</h3>
              </div>
            </CardHeader>
            <CardFooter className="card-footer">
              <p ><span className="text-success text-sm">+55% </span>so với cùng kỳ</p>
            </CardFooter>
          </Card>
        </div>
        <div style={{width: "25%", padding: "0 10px"}}>
          <Card className="card">
            <CardHeader className="card-header">
              <div className="icon">
                
              </div>
              <div className="text-end">
                <p className="text-sm">Doanh thu hôm nay</p>
                <h3 >53đ</h3>
              </div>
            </CardHeader>
            <CardFooter className="card-footer">
              <p ><span className="text-success text-sm">+55% </span>so với cùng kỳ</p>
            </CardFooter>
          </Card>
        </div>
        <div style={{width: "25%", padding: "0 10px"}}>
          <Card className="card">
            <CardHeader className="card-header">
              <div className="icon">
                
              </div>
              <div className="text-end">
                <p className="text-sm">Doanh thu hôm nay</p>
                <h3 >53đ</h3>
              </div>
            </CardHeader>
            <CardFooter className="card-footer">
              <p ><span className="text-success text-sm">+55% </span>so với cùng kỳ</p>
            </CardFooter>
          </Card>
        </div>
        <div style={{width: "25%", padding: "0 10px"}}>
          <Card className="card">
            <CardHeader className="card-header">
              <div className="icon">
                
              </div>
              <div className="text-end">
                <p className="text-sm">Doanh thu hôm nay</p>
                <h3 >53đ</h3>
              </div>
            </CardHeader>
            <CardFooter className="card-footer">
              <p ><span className="text-success text-sm">+55% </span>so với cùng kỳ</p>
            </CardFooter>
          </Card>
        </div>
          </Row>
          <Row style={{marginTop: "1.5rem", display: "flex", justifyContent: "center"}}>
        <div class="chart">
          <div class="card">
            <div class="card-header-chart">
                <div class="chart">
                <BarChart width={450} height={300} data={data1}>
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="name" />
                  <YAxis />
                  <Tooltip />
                  <Bar dataKey="pv" fill="#8884d8" />
                  <Bar dataKey="uv" fill="#82ca9d" />
                </BarChart>
                </div>
            </div>
            <div class="card-body">
              <h2>Lượt truy cập</h2>
              <p class="text-sm ">Hiệu suất</p>
              <div class="card-footer">
                <AccessTimeIcon/>
                <p class="mb-0 text-sm"> cập nhật 2 ngày trước </p>
              </div>
            </div>
          </div>
        </div>
        <div class="chart">
            <div class="card">
              <div class="card-header-chart">
                <div class="chart">
                  <LineChart width={450} height={300} data={data1}>
                    <Line type="monotone" dataKey="uv" stroke="#8884d8" />
                    <Line dataKey="pv" stroke="#8884d8" type="monotone"/>
                    <XAxis dataKey="name" />
                    <YAxis />
                    <Tooltip />
                  </LineChart>
                </div>
              </div>
            <div class="card-body">
              <h2>Lượng hàng bán ra</h2>
              <p class="text-sm "> (<span class="font-weight-bolder">+15%</span>) </p>
              <div class="card-footer">
                <AccessTimeIcon/>
                <p class="mb-0 text-sm"> cập nhật 4 phút trước </p>
              </div>
            </div>
            </div>
          </div>
          </Row>
        </div>
    </div>
    )
}

export default AdminPage;
