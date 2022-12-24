import './App.css';
import { Routes, Route } from "react-router-dom"
import Home from "./routes/Home"
import About from "./routes/About"
import Contact from "./routes/Contact"
import AppBar from "@mui/material/AppBar";
import Toolbar from '@mui/material/Toolbar';
import Button from "@mui/material/Button";
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Typography from '@mui/material/Typography';

function App() {
  return (
    <div className="App">
      <AppBar display="flex" position="static">
        <Toolbar>
            <IconButton
              size="large"
              edge="start"
              color="inherit"
              aria-label="menu"
              sx={{ mr: 0 }}
            >
              <MenuIcon />
            </IconButton>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              Training plan app
            </Typography>
            <Button color="inherit">Login</Button>
            <Button color="inherit">Register</Button>
          </Toolbar>
      </AppBar>
      <Routes>
          <Route path="/" element={ <Home/> } />
          <Route path="about" element={ <About/> } />
          <Route path="contact" element={ <Contact/> } />
        </Routes>
  </div>
  );
}

export default App;
