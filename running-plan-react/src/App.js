import './App.css';
import * as React from 'react';
import { Routes, Route } from "react-router-dom"
import Home from "./routes/Home"
import About from "./routes/About"
import Contact from "./routes/Contact"
import Login from "./routes/Login"
import Signup from "./routes/Signup"
import AppBar from "@mui/material/AppBar";
import Toolbar from '@mui/material/Toolbar';
import Button from "@mui/material/Button";
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Typography from '@mui/material/Typography';
import { useNavigate } from "react-router-dom";
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import MailIcon from '@mui/icons-material/Mail';
import StepperCreatePlan from './routes/StepperCreatePlan';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';


const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

function App() {
  let navigate = useNavigate();

  const [state, setState] = React.useState({
    top: false,
    left: false,
    bottom: false,
    right: false,
  });

  function loginPage() {
    navigate("/login");
  }

  function SignUpPage() {
    navigate("/signup");
  }

  function homePage() {
    navigate("/");
  }

  const toggleDrawer = (anchor, open) => (event) => {
    if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
      return;
    }

    setState({ ...state, [anchor]: open });
  };

  const list = (anchor) => (
    <Box
      sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250 }}
      role="presentation"
      onClick={toggleDrawer(anchor, false)}
      onKeyDown={toggleDrawer(anchor, false)}
    >
      <List>
        {['Create Plan', 'My Plan', 'Contact Trainer'].map((text, index) => (
          <ListItem key={text} disablePadding>
            <ListItemButton>
              <ListItemIcon>
                {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItemButton>
          </ListItem>
        ))}
      </List>
      <Divider />
      <List>
        {['Info', 'Contact', 'About'].map((text, index) => (
          <ListItem key={text} disablePadding>
            <ListItemButton>
              <ListItemIcon>
                {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItemButton>
          </ListItem>
        ))}
      </List>
    </Box>
  );

  return (
    <div className="App">
      <ThemeProvider theme={darkTheme}>
      <CssBaseline />
      <AppBar display="flex" position="static">
        <Toolbar>
            <Drawer
                anchor='left'
                open={state['left']}
                onClose={toggleDrawer('left', false)}
              >
                {list('left')}
            </Drawer>
            <IconButton
              onClick={toggleDrawer('left', true)}
              size="large"
              edge="start"
              color="inherit"
              aria-label="menu"
              sx={{ mr: 0 }}
            >
              <MenuIcon />
            </IconButton>
            <Button onClick={homePage} color="inherit">My Plan</Button>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            </Typography>
            <Button onClick={loginPage} label="login" color="inherit">Login</Button>
            <Button onClick={SignUpPage} color="inherit">SignUp</Button>
          </Toolbar>
      </AppBar>
      <Routes>
          <Route path="/" element={ <Home/> } />
          <Route path="stepper" element={ <StepperCreatePlan/> } />
          <Route path="about" element={ <About/> } />
          <Route path="contact" element={ <Contact/> } />
          <Route path="login" element={ <Login/> } />
          <Route path="signup" on element={ <Signup/> } />
      </Routes>
      </ThemeProvider>
  </div>
  );
}

export default App;
