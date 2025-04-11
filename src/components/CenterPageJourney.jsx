import Fleche from '../assets/Images/Icones/Fleche.png';

function Filters() {
    return (
        <div class="centerpage">
            <section class="filters">
            <h3>Confiance et sécurité</h3>
            <ul>
                <li><input type="checkbox"/> Chauffeur vérifié</li>
                <li><input type="checkbox" /> Super Chauffeur</li>
                <li><input type="checkbox"/> Véhicule vérifié</li>
                <li><input type="checkbox" /> Véhicule électrique</li>
                <li><input type="checkbox" /> Siège inclinable</li>
                <li><input type="checkbox" /> Climatisation</li>
            </ul>
            <h3>Option de trajet</h3>
            <ul>
                <li><input type="checkbox" /> Animaux autorisés</li>
                <li><input type="checkbox" /> Trajet en musique</li>
                <li><input type="checkbox" /> Max 2 à l'arrière</li>
                <li><input type="checkbox" /> Prise électrique</li>
                <li><input type="checkbox" /> Siège inclinable</li>
                <li><input type="checkbox" /> Climatisation</li>
                <li><input type="checkbox" /> Cigarette autorisée</li>
            </ul>
            </section>
            <section class="results">
                <div class="result-card">
                    <h4>Coucou</h4>
                    <p>A dialog is a type of modal window...</p>
                    <div class="route">
                        <span>Lille</span>
                        <img src={Fleche} alt="Arrow"/>
                        <span>Bordeaux</span>
                        <span class="price">0.00€</span>
                    </div>
                </div>
                <div class="result-card">
                    <h4>Coucou</h4>
                    <p>A dialog is a type of modal window...</p>
                    <div class="route">
                        <span>Lille</span>
                        <img src={Fleche} alt="Arrow"/>
                        <span>Bordeaux</span>
                        <span class="price">0.00€</span>
                    </div>
                </div>
                <div class="result-card">
                    <h4>Coucou</h4>
                    <p>A dialog is a type of modal window...</p>
                    <div class="route">
                        <span>Lille</span>
                        <img src={Fleche} alt="Arrow"/>
                        <span>Bordeaux</span>
                        <span class="price">0.00€</span>
                    </div>
                </div>
                <div class="result-card">
                    <h4>Coucou</h4>
                    <p>A dialog is a type of modal window...</p>
                    <div class="route">
                        <span>Lille</span>
                        <img src={Fleche} alt="Arrow"/>
                        <span>Bordeaux</span>
                        <span class="price">0.00€</span>
                    </div>
                </div>
                <div class="result-card">
                    <h4>Coucou</h4>
                    <p>A dialog is a type of modal window...</p>
                    <div class="route">
                        <span>Lille</span>
                        <img src={Fleche} alt="Arrow"/>
                        <span>Bordeaux</span>
                        <span class="price">0.00€</span>
                    </div>
                </div>
                <div class="result-card">
                    <h4>Coucou</h4>
                    <p>A dialog is a type of modal window...</p>
                    <div class="route">
                        <span>Lille</span>
                        <img src={Fleche} alt="Arrow"/>
                        <span>Bordeaux</span>
                        <span class="price">0.00€</span>
                    </div>
                </div>
                <div class="result-card">
                    <h4>Coucou</h4>
                    <p>A dialog is a type of modal window...</p>
                    <div class="route">
                        <span>Lille</span>
                        <img src={Fleche} alt="Arrow"/>
                        <span>Bordeaux</span>
                        <span class="price">0.00€</span>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default Filters;
