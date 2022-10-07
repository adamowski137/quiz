import './App.css';
import Home from './webpage/Home.js';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Quiz from './webpage/Quiz';

function App() {
  return(
    <div>
      <div className='navbar'>

      </div>
      <div className='page-container'>
        <Router>
          <Routes>
              <Route exact path='/quiz/:id' element={<Quiz />} />
          </Routes>
        </Router>
      </div>
    </div>
  )
  
}

export default App;