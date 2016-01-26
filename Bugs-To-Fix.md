### Général

* Appuyer sur précédent revient mm sur les formulaires


### Profil

* Peut rajouter plusieurs fois le même user comme contact --> fixed !
* Peut se rajouter comme étant son propre contact --> fixed !
* Le fragment de saisie du statut est trop petit
* Affichage du nom et prénom de l'utilisateur au dessus du pseudo --> fixed !
* Lorsque l'on se connecte avec un utilisateur déjà présent dans la BDD, le current_user dans Profile est vide. Faut passer par l'enregistrement.

### Evénements

* Actions non connectés en totalité

### Groupes

* L'ajout d'un membre dans le groupe l'ajoute 2 fois --> fixed !
* Peut rajouter plusieurs fois le même membre dans le groupe --> fixed !

### Fragments et Adapters

* Adapter le format des fragments (afficher en fullView)


### Connexion

* Peut revenir sur la page de connexion sans se déconnecter (par appui sur précédent)! à ce moment là l'utilisateur n'est plus reconnu.
