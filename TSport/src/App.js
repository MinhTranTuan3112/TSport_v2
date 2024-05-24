import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import AdminPage from "./components/AdminPage";
import ManageUser from "./components/ManageUser";
import ManageProduct from "./components/ManageProduct";
import ViewOrder from "./components/ViewOrder";
function App() {

  return (
    <div className="App">
      <Router>
        
            <Routes>
              <Route path="/admin" element={<AdminPage/>} />
              <Route path="/user" element={<ManageUser/>} />
              <Route path="/product" element={<ManageProduct/>}/>
              <Route path="/order" element={<ViewOrder/>}/>
            </Routes>
      </Router>
    </div>
  );
}

export default App;
