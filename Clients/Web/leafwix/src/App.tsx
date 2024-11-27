import { Routes, Route, Navigate } from 'react-router-dom';
import { PersistLogin, RequireAuth, CheckAuth } from './features/authentication';
import Login from './pages/Login';
import Register from './pages/Register';
import ForgotPassword from './pages/ForgotPassword';
import ResetPassword from './pages/ResetPassword';
import Home from "./pages/Home";


const App = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/login" />} />

      <Route element={<PersistLogin />}>
        {/* private routes */}
          <Route element={<RequireAuth allowedRoles={["User"]} />}>
            <Route path="/home/*" element={<Home />} />
          </Route>
          {/* public routes */}
          <Route element={<CheckAuth />}>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/forgotpassword" element={<ForgotPassword />} />
            <Route path="/resetpassword/*" element={<ResetPassword />} />
          </Route>
      </Route>

      {/* <Route path='*' element={<NotFound />} /> */}
    </Routes>
  )
}

export default App
