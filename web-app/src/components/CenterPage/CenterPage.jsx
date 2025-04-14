import { Routes, Route } from 'react-router-dom';

import HomePage from './HomePage/HomePage.jsx';
import Publish from './Publish/Publish.jsx';
import Journey from './Journey/Journey.jsx';
import Community from './Community/Community.jsx';
import Help from './Help/Help.jsx';
import Profile from './Profile/Profile.jsx';
import Search from './Search/Search.jsx';
import We from './We/We.jsx';

function CenterPage() {
  return (
    <div className="centerpage">
      <Routes>
        <Route path="/HomePage" element={<HomePage />} />
        <Route path="/Searchpage" element={<Search />} />
        <Route path="/Publishpage" element={<Publish />} />
        <Route path="/Journeyspage" element={<Journey />} />
        <Route path="/Communitypage" element={<Community />} />
        <Route path="/Helppage" element={<Help />} />
        <Route path="/Profile" element={<Profile />} />
        <Route path="/We" element={<We />} />
      </Routes>
    </div>
  );
}

export default CenterPage;