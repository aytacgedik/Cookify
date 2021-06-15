import React from 'react';
import {
    StyleSheet,
    ScrollView,
    Text,
    TextInput,
    View,
    TouchableOpacity
} from 'react-native';

const CreateRecipeView = (props) => {

    
    const createRecipe = () => {

    }

return(
<ScrollView style={{marginLeft:20}}>
    <Text style={{fontSize: 20, marginBottom: 15, paddingTop: 20}}>Adding new entry: </Text>
    <Text style={styles.description}>Creator Id: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}/>
    </View>
    
    <Text style={styles.description}>Name: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}/>
    </View>
    <Text style={styles.description}>Description: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}/>
    </View> 
    <Text style={styles.description}>Rating: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}/>
    </View>
    <Text style={styles.description}>Tag: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}/>
    </View>
    <Text style={styles.description}>Ingredients: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}/>
    </View>
    <TouchableOpacity style={styles.createBtn} onPress={createRecipe}>
        <Text style={styles.createText}>Add</Text>
    </TouchableOpacity>
</ScrollView>);
}

export default CreateRecipeView;

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
    createText: {
        fontWeight: "bold",
        fontSize: 16,
    },
    createBtn: {
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