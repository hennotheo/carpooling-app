# Git-flow documentation

## Branches

### Main

La branche main est la branch principale du projet. C'est la branche qui contient le code en production. Elle ne doit pas recevoir de code directement.
Elle est mise à jour à partir de la branche dev uniquement.

### Dev

Les branches dev sont les branches de développement. Elles sont créées à partir de la branche main et sont fusionnées dans la branche main lorsqu'une version est prête à être déployée.
Elles prennent un nom de la forme dev/vMAJOR.MINOR.PATCH et ne doivent pas recevoir de code directement. Elles reçoivent le code des branches feature via des pull requests.

*Exemple de nom d'une branche dev "dev/v0.2.1"*

### Feature

Les branches feature sont les branches de développement des fonctionnalités. Elles sont créées à partir de la branche dev/vX.X et sont fusionnées dans la branche dev/vX.X lorsqu'une fonctionnalité est
prête.
Elles prennent un nom de la forme feature/ID-NOM_FEATURE et reçoivent le code des développeurs.

- ID : identifiant de la fonctionnalité (Numéro de l'Issue dans github)
- NOM_FEATURE : nom de la fonctionnalité

*Exemple de nom d'une branche feature "feature/21-profile-page"*

### Hotfix

Les branches hotfix sont les branches de correction de bugs.
Elles sont créées à partir de la branche main et sont fusionnées dans la branche main et dev/vX.X lorsqu'un bug est corrigé.
Elles prennent un nom de la forme hotfix/vMAJOR.MINOR.PATCH-NOM_BUG et reçoivent le code des développeurs.

*Exemple de nom d'une branche Hotfix "hotfix/v0.2.4-cant-modify-profile"*

## Workflow

On va prendre l'example de la fonctionnalité "Ajouter un bouton de connexion" pour expliquer le workflow.

### Developper une fonctionnalité

#### Créer la branche feature

1. **Aller sur la branche dev/vX.X**
    ```bash
    git checkout dev/vX.X
    ```
2. **Pull les modifications de la branche dev**
    ```bash
    git pull
    ```
3. **Créer la branche feature**
   ```bash
   git checkout -b feature/13-add-login-button
   ```
4. **Push la branche feature**
   ```bash
   git push --set-upstream origin feature/13-add-login-button
   ```

#### Développer la fonctionnalité

1. **Coder la fonctionnalité (logique)**
2. **Add les changements necessaires.**
    ```bash
    git add .
    ```
   Pour Add tout les changements sur tout les fichiers en dehors de ceux dans le gitignore.
   ```bash
   git add folder/folder2/file.js
    ```
   pour add un fichier spécifique.
3. **Commit les changements**
    ```bash
    git commit -m "Add login button"
    ```
4. **Push les changements**
    ```bash
    git push
    ```
5. **Faire iterer jusqu'à ce que la fonctionnalité soit terminée**

#### Submit la fonctionnalité

1. **Créer une pull request**
    - Aller sur la page du projet sur github
    - Cliquer sur "Pull requests"
    - Cliquer sur "New pull request"
    - Choisir la branche dev/vX.X comme base
    - Choisir la branche feature/13-add-login-button comme head
    - Me mettre en reviewer (Théo)
    - Cliquer sur "Create pull request"

2. **Attendre la review**
3. **Faire les modifications necessaires si demandés**

### Faire un hotfix

Meme proceder que pour une feature mais en partant de la branche main.

### Reste

Tout le reste je le ferais moi meme donc je vais pas detailler le workflow spécifiquement. 
Normalement vous n'aurez pas à vous occuper de plus de truc que ce que j'ai decris.