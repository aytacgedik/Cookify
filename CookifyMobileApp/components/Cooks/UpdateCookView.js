import React, {useState} from 'react';
import {
    StyleSheet,
    ScrollView,
    Text,
    TextInput,
    View,
    TouchableOpacity,
    CheckBox
} from 'react-native';
import axios from 'axios';

const api_url = "https://cookifyv2.azurewebsites.net/api/users"

const UpdateCookView = (props) => {

    const {navigation, cook} = props.route.params;

    const id = useState(cook.id);
    const [name, setName] = useState(cook.name);
    const [surname, setSurname] = useState(cook.surname);
    const [email, setEmail] = useState(cook.email);
    const [verified, setVerified] = useState(cook.verified);
    const [admin, setAdmin] = useState(cook.admin);
    const [savedRecipes, setSavedRecipes] = useState(cook.savedRecipes);

    const changeName = (e) => {
        setName(e);
    }
    const changeSurname = (e) => {
        setSurname(e);
    }
    const changeEmail = (e) => {
        setEmail(e);
    }
    const changeVerified = (e) => {
        setVerified(e);
    }
    const changeAdmin = (e) => {
        setAdmin(e);
    }
    
    const updateCook = () => {
        axios.patch(`${api_url}/${cook.id}`, {
            "id": id,
            "name": name,
            "surname": surname,
            "email": email,
            "verified": verified,
            "admin": admin,
            "savedRecipes": savedRecipes
        }).then(res => {
            navigation.push("CooksList")
        })
    }

return(
<ScrollView style={{marginLeft:20}}>
    <Text style={{fontSize: 20, marginBottom: 15, paddingTop: 20}}>Adding new entry: </Text>
    
    <Text style={styles.description}>Name: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {name}
            style={styles.TextInput}
            onChangeText = {(e) => changeName(e)}/>
    </View>
    <Text style={styles.description}>Surname: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {surname}
            style={styles.TextInput}
            onChangeText = {(e) => changeSurname(e)}/>
    </View> 
    <Text style={styles.description}>Email: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {email}
            style={styles.TextInput}
            onChangeText = {(e) => changeEmail(e)}/>
    </View>
    <Text style={styles.description}>Verified: </Text>
    <View style={styles.inputView}>
        <CheckBox
            value = {verified}
            style={styles.TextInput}
            value={verified}
            onValueChange = {(e) => changeVerified(e)}/>
    </View>
    <Text style={styles.description}>Admin: </Text>
    <View style={styles.inputView}>
        <CheckBox
            value = {admin}
            style={styles.TextInput}
            value={admin}
            onValueChange = {(e) => changeAdmin(e)}/>
    </View>
    <TouchableOpacity style={styles.updateBtn} onPress={updateCook}>
        <Text style={styles.updateText}>Update</Text>
    </TouchableOpacity>
</ScrollView>);
}

export default UpdateCookView;

const styles = StyleSheet.create({
  
    inputView: {
      backgroundColor: "#d0f0c0",
      borderRadius: 20,
      width: 240,
      height: 45,
      marginBottom: 20,
    },
    TextInput: {
        height: 50,
        flex: 1,
        padding: 10,
        marginLeft: 10,
        opacity: 0.6,
    },
    updateText: {
        fontWeight: "bold",
        fontSize: 16,
    },
    updateBtn: {
        //width: "80%",
        width: 150,
        borderRadius: 20,
        height: 50,
        alignItems: "center",
        justifyContent: "center",
        marginTop: 20,
        marginBottom: 300,
        backgroundColor: "#00ff00",
    },
    description: {
      marginBottom: 8,
      marginLeft: 8
    }
  });