import { Routes, Route } from 'react-router-dom';

import HomePage from './HomePage/HomePage';
import Publish from './Publish/Publish';
import Journey from './Journey/Journey';
import Community from './Community/Community';
import Help from './Help/Help';
import Profile from './Profile/Profile';

function CenterPage() {
  return (
    <div className="centerpage">
      <Routes>
        <Route path="/HomePage" element={<HomePage />} />
        <Route path="/Publishpage" element={<Publish />} />
        <Route path="/Journeyspage" element={<Journey />} />
        <Route path="/Communitypage" element={<Community />} />
        <Route path="/Helppage" element={<Help />} />
        <Route path="/Profile" element={<Profile />} />
      </Routes>
    </div>
  );
}

export default CenterPage;